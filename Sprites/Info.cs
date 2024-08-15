using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.Sprites
{
    public class Info
    {
        //----------------------------------------------------------------------------------------------------------------------------
        public int actualSpeed = 1;
        public int bouceCount = 0;
        public int topSpeed = 0;
        public int topBounce = 0;
        //----------------------------------------------------------------------------------------------------------------------------
        private SpriteFont font;
        //----------------------------------------------------------------------------------------------------------------------------
        public Info(SpriteFont font) { this.font = font; LoadScore(); }
        //----------------------------------------------------------------------------------------------------------------------------
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Top speed: " + GetText(topSpeed), new Vector2(10, 610), Color.DarkSlateGray);
            spriteBatch.DrawString(font, "Top bounce: " + GetText(topBounce), new Vector2(10, 630), Color.DarkSlateGray);
            spriteBatch.DrawString(font, "Actual speed: " + GetText(actualSpeed), new Vector2(10, 650), Color.DarkSlateGray);
            spriteBatch.DrawString(font, "Bounce count: " + GetText(bouceCount), new Vector2(10, 670), Color.DarkSlateGray);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public string GetText(int number, int charsCount = 1)
        {
            return number.ToString().PadLeft(charsCount, '0');
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected void LoadScore()
        {
            string iniFile = Path.Combine(Directory.GetCurrentDirectory(), "score.txt");

            if (!File.Exists(iniFile)) 
            {
                File.Create(iniFile);
                IniFile.IniSave(iniFile, "SCORE", "TOPSPEED", "0");
                IniFile.IniSave(iniFile, "SCORE", "TOPBOUNCE", "0");
            }
            else
            {
                topSpeed = Convert.ToInt32(IniFile.IniLoad(iniFile, "SCORE", "TOPSPEED"));
                topBounce = Convert.ToInt32(IniFile.IniLoad(iniFile, "SCORE", "TOPBOUNCE"));
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
