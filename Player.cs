using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    class Player : Sprite
    {
        public KeyboardState keyState, lastKey;

        public Player(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle playField) : base(texture, position, direction, speed, playField)
        {
            SetStarPosition();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update(GameTime gameTime)
        {
            lastKey = keyState;
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;

                if (position.Y < 15)
                {
                    position.Y = 15;
                }
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                position.Y += speed;

                if (position.Y > 720 - 15 - 120)
                {
                    position.Y = 720 - 15 - 120;
                }
            }

            base.Update(gameTime);
        }
        //----------------------------------------------------------------------------------------------------------------------------

        public void SetStarPosition()
        {
            position.Y = playField.Height / 2 - texture.Height / 2;
        }
    }
}
