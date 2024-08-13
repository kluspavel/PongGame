using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace PongGame
{
    class Ball : Sprite
    {
        private Texture2D texture;
        private float speedX = 5f;
        private float speedY = 5f;
        //----------------------------------------------------------------------------------------------------------------------------
        public Ball(Texture2D texture) : base(texture)
        {
            this.texture = texture;
            SetStartPosition();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update()
        {
            Move();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void Move()
        {
            Position.X += speedX;
            if (Position.X < 10)
            {
                Position.X = 10;
                speedX *= -1;
            }

            if (Position.X > 1280 - texture.Width - 10) 
            {
                
                Position.X = 1280 - texture.Width - 10;
                speedX *= -1;
            }

            Position.Y += speedY;
            if (Position.Y < 15)
            {
                Position.Y = 15;
                speedY *= -1;
            }

            if (Position.Y > 720 - texture.Height - 15)
            {
                Position.Y = 720 - texture.Height - 15;
                speedY *= -1;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void SetStartPosition()
        {
            Position.X = 1280 / 2 - texture.Width / 2;
            Position.Y = 720 / 2 - texture.Height / 2;

            Random random = new();
            speedX = random.Next(1, 10) <= 5 ? -5 : 5;
            speedY = random.Next(1, 5) * (random.Next(1, 10) <= 5 ? -1 : 1);
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
