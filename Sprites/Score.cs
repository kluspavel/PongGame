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
            spriteBatch.DrawString(font, ScoreOne.ToString(), new Vector2(0,0), Color.White);
            spriteBatch.DrawString(font, ScoreOne.ToString(), new Vector2(0, 0), Color.White);
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
