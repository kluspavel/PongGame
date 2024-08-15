using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
        //----------------------------------------------------------------------------------------------------------------------------
        private SpriteFont font;
        //----------------------------------------------------------------------------------------------------------------------------
        public Info(SpriteFont font) { this.font = font; }
        //----------------------------------------------------------------------------------------------------------------------------
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Actual speed: " + GetText(actualSpeed), new Vector2(20, 650), Color.Gray);
            spriteBatch.DrawString(font, "Bounce count: " + GetText(bouceCount), new Vector2(20, 670), Color.Gray);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public string GetText(int number, int numberChars = 1)
        {
            return number.ToString().PadLeft(numberChars, '0');
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
