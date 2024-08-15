using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame.Sprites
{
    public class Score
    {
        //----------------------------------------------------------------------------------------------------------------------------
        public int ScoreOne;
        public int ScoreTwo;
        //----------------------------------------------------------------------------------------------------------------------------
        private SpriteFont font;
        //----------------------------------------------------------------------------------------------------------------------------
        public Score(SpriteFont font) { this.font = font; }
        //----------------------------------------------------------------------------------------------------------------------------
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(font, GetText(ScoreTwo), new Vector2(GetTextWidth(GetText(ScoreTwo), 50), 30), Color.Red);
            spriteBatch.DrawString(font, GetText(ScoreOne), new Vector2(GetTextWidth(GetText(ScoreOne), -50), 30), Color.Blue);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public string GetText(int number, int charsCount = 2)
        {
            return number.ToString().PadLeft(charsCount, '0');
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public float GetTextWidth(string text, float offset)
        {
            return Pong.ScreenWidth / 2 - font.MeasureString(text).X / 2 + offset;
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
