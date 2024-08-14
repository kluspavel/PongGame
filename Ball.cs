using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace PongGame
{
    class Ball : Sprite
    {
        //private Texture2D texture;
        //private float speedX = 5f;
        //private float speedY = 5f;
        //----------------------------------------------------------------------------------------------------------------------------
        public Ball(Texture2D texture, Rectangle field) : base(texture, field)
        {
            this.texture = texture;
            this.field = field;
            SetStartPosition();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            Position += Velocity;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void Move()
        {
            if (IsOutOfTop(15))
            {
                Velocity.Y = -Speed.Y;
            }
            else if (IsOutOfBottom(-15))
            {
                Velocity.Y = Speed.Y;
            }
            else if (IsOutOfLeft(10))
            {
                Velocity.X = Speed.X;
            }
            else if (IsOutOfRight(-10))
            {
                Velocity.X = -Speed.X;
            }




            //Position.X += Velocity.X;
            //if (Position.X < 10)
            //{
            //    Position.X = 10;
            //    Velocity.X *= -1;
            //}

            //if (Position.X > 1280 - texture.Width - 10) 
            //{

            //    Position.X = 1280 - texture.Width - 10;
            //    Velocity.X *= -1;
            //}

            //Position.Y += Velocity.Y;
            //if (Position.Y < 15)
            //{
            //    Position.Y = 15;
            //    Velocity.Y *= -1;
            //}

            //if (Position.Y > 720 - texture.Height - 15)
            //{
            //    Position.Y = 720 - texture.Height - 15;
            //    Velocity.Y *= -1;
            //}
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void SetStartPosition()
        {
            Position.X = 1280 / 2 - texture.Width / 2;
            Position.Y = 720 / 2 - texture.Height / 2;

            Random random = new();
            //speedX = random.Next(1, 10) <= 5 ? -5 : 5;
            //speedY = random.Next(1, 5) * (random.Next(1, 10) <= 5 ? -1 : 1);

            Speed.X = random.Next(1, 10) <= 5 ? -5 : 5;
            Speed.Y = random.Next(1, 5) * (random.Next(1, 10) <= 5 ? -1 : 1);

            Velocity = Speed;
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
