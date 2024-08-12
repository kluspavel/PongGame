using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    public class Player : Sprite
    {
        private Texture2D texture;
        //----------------------------------------------------------------------------------------------------------------------------
        public Input Input { get; set; }
        public float Speed { get; set; }
        //----------------------------------------------------------------------------------------------------------------------------
        public Player(Texture2D texture) : base(texture) 
        { 
            this.texture = texture;
            Speed = 5f;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update()
        {
            Move();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void Move() 
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Position.Y -= Speed;
                if (Position.Y < 15)
                {
                    Position.Y = 15;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Position.Y += Speed;
                if (Position.Y > 720 - texture.Height - 15)
                {
                    Position.Y = 720 - texture.Height - 15;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
        //----------------------------------------------------------------------------------------------------------------------------






        //public KeyboardState keyState, lastKey;

        //public Player(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle playField) : base(texture, position, direction, speed, playField)
        //{
        //    SetStarPosition();
        //}
        ////----------------------------------------------------------------------------------------------------------------------------
        //public override void Update(GameTime gameTime)
        //{
        //    lastKey = keyState;
        //    keyState = Keyboard.GetState();

        //    if (keyState.IsKeyDown(Keys.W))
        //    {
        //        position.Y -= speed;

        //        if (position.Y < 15)
        //        {
        //            position.Y = 15;
        //        }
        //    }

        //    if (keyState.IsKeyDown(Keys.S))
        //    {
        //        position.Y += speed;

        //        if (position.Y > 720 - 15 - 120)
        //        {
        //            position.Y = 720 - 15 - 120;
        //        }
        //    }

        //    base.Update(gameTime);
        //}
        ////----------------------------------------------------------------------------------------------------------------------------

        //public void SetStarPosition()
        //{
        //    position.Y = playField.Height / 2 - texture.Height / 2;
        //}
    }
}
