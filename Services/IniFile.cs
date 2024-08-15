using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace PongGame
{
    public static class IniFile
    {
        //----------------------------------------------------------------------------------------------------
        #region DLL IMPORT

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string file);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string define, StringBuilder value, int size, string file);

        #endregion
        //----------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------------------
        #region DLL FUNKCE INI SOUBORU

        public static void IniSave(this string IniDir, string section, string key, string hodnota)
        {
            string exe = Assembly.GetExecutingAssembly().GetName().Name;
            string slozka = new FileInfo(IniDir ?? exe + ".ini").FullName.ToString();
            WritePrivateProfileString(section ?? exe, key, hodnota, slozka);
        }
        //----------------------------------------------------------------------------------------------------
        public static string IniLoad(this string IniDir, string section, string key)
        {
            string exe = Assembly.GetExecutingAssembly().GetName().Name;
            string slozka = new FileInfo(IniDir ?? exe + ".ini").FullName.ToString();
            StringBuilder hodnota = new StringBuilder(255);
            int i = GetPrivateProfileString(section ?? exe, key, "", hodnota, 255, slozka);
            return hodnota.ToString();
        }
        //----------------------------------------------------------------------------------------------------
        public static void IniDeleteKey(this string IniDir, string key, string section = null)
        {
            string exe = Assembly.GetExecutingAssembly().GetName().Name;
            IniDir.IniSave(section ?? exe, key, null);
        }
        //----------------------------------------------------------------------------------------------------
        public static void IniDeleteSection(this string IniDir, string section)
        {
            string exe = Assembly.GetExecutingAssembly().GetName().Name;
            IniDir.IniSave(section ?? exe, null, null);
        }
        //----------------------------------------------------------------------------------------------------
        public static bool IniExistKey(this string IniDir, string key, string section = null)
        {
            return IniDir.IniLoad(section, key).Length > 0;
        }

        #endregion
        //----------------------------------------------------------------------------------------------------
    }
}
