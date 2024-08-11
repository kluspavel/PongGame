using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    class Score
    {
        //----------------------------------------------------------------------------------------------------------------------------
        protected SpriteFont font;
        //----------------------------------------------------------------------------------------------------------------------------
        protected string text;
        //----------------------------------------------------------------------------------------------------------------------------
        protected int scoreFirst;
        //----------------------------------------------------------------------------------------------------------------------------
        protected Ball ball;
        //----------------------------------------------------------------------------------------------------------------------------
        public int ScoreFirst
        {
            get { return scoreFirst; }
            set { scoreFirst = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected int scoreSecond;
        //----------------------------------------------------------------------------------------------------------------------------
        public int ScoreSecond
        {
            get { return scoreSecond; }
            set { scoreSecond = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected Vector2 position;
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected Color fontColor;
        //----------------------------------------------------------------------------------------------------------------------------
        public Color FontColor
        {
            get { return fontColor; }
            set { fontColor = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected Rectangle playField;
        //----------------------------------------------------------------------------------------------------------------------------
        public Score(SpriteFont font, Color fontColor, Rectangle playField, Ball ball) 
        {
            this.font = font;
            this.fontColor = fontColor;
            this.playField = playField;
            this.ball = ball;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Update(GameTime gameTime)
        {
            if (ball.Position.X > playField.Width)
            {
                ScoreFirst++;
                ball.SetStartPosition();
            }

            if (ball.Position.X < -20)
            {
                scoreSecond++;
                ball.SetStartPosition();
            }

            text = scoreFirst.ToString().PadLeft(2, '0') + "   " + scoreSecond.ToString().PadLeft(2, '0');
            Vector2 textSize = font.MeasureString(text);
            position.X = playField.Width / 2 - textSize.X / 2;
            position.Y = 30;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, fontColor);
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
