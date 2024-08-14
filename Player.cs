using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace PongGame
{
    public class Player : Sprite
    {
        //----------------------------------------------------------------------------------------------------------------------------
        public Player(Texture2D texture, Rectangle field) : base(texture, field) 
        { 
            this.texture = texture;
            this.field = field;
            Speed.X = 0f;
            Speed.Y = 6f;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            if (Velocity.Y < 0 && IsOutOfTop(15))
            {
                Velocity.Y = 0;
                Position.Y = 15;
            }
            else if (Velocity.Y > 0 && IsOutOfBottom(-15))
            {
                Velocity.Y = 0;
                Position.Y = field.Bottom - texture.Height - 15;
            }

            Position += Velocity;

            if (Velocity.Y != 0)
            {
                Velocity.Y = 0;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void Move() 
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up) && Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed.Y;
            }
        }
    }
}
