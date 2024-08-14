using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame.Sprites
{
    public class Player : Sprite
    {
        //----------------------------------------------------------------------------------------------------------------------------
        public Player(Texture2D texture) : base(texture)
        {
            Speed.X = 0f; 
            Speed.Y = 6f;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);

            if (Input == null)
            {
                throw new Exception("Please give a value to 'Input'");
            }

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed.Y;
            }

            Position += Velocity;

            Position.Y = MathHelper.Clamp(Position.Y, 0, Pong.ScreenHeight - texture.Height);

            Velocity = Vector2.Zero;
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
