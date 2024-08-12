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
        //----------------------------------------------------------------------------------------------------------------------------
        public Ball(Texture2D texture) : base(texture)
        {
            
        }




        ////----------------------------------------------------------------------------------------------------------------------------
        //public Ball(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle playField) : base(texture, position, direction, speed, playField)
        //{
        //    SetStartPosition();
        //}
        ////----------------------------------------------------------------------------------------------------------------------------
        //public override void Update(GameTime gameTime)
        //{
        //    BoundsScreen();
        //    base.Update(gameTime);
        //}
        ////----------------------------------------------------------------------------------------------------------------------------
        //private void BoundsScreen()
        //{
        //    if (position.X > playField.Width - texture.Width - 10)
        //    {
        //        direction.X *= -1;
        //        position.X = playField.Width - texture.Width - 10;
        //    }

        //    if (position.X < playField.X + 10)
        //    {
        //        direction.X *= -1;
        //        position.X = playField.X + 10;
        //    }

        //    if (position.Y > playField.Height - texture.Height - 15)
        //    {
        //        direction.Y *= -1;
        //        position.Y = playField.Height - texture.Height - 15;
        //    }

        //    if (position.Y < playField.Y + 15)
        //    {
        //        direction.Y *= -1;
        //        position.Y = playField.Y + 15;
        //    }
        //}
        ////----------------------------------------------------------------------------------------------------------------------------
        //public void SetStartPosition()
        //{
        //    position.X = playField.Width / 2 - texture.Width / 2;
        //    position.Y = playField.Height / 2 - texture.Height / 2;

        //    Random random = new();
        //    direction.X = random.Next(1, 10) <= 5 ? -5 : 5;
        //    direction.Y = random.Next(1, 5) * (random.Next(1, 10) <= 5 ? -1 : 1);
        //}
    }
}
