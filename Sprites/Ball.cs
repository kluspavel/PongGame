using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PongGame.Sprites
{
    public class Ball : Sprite
    {
        //----------------------------------------------------------------------------------------------------------------------------
        private float timer = 0f;
        private Vector2? startPosition;
        private Vector2? startSpeed;
        private bool isPlaying;
        //----------------------------------------------------------------------------------------------------------------------------
        public Score Score { get; private set; }
        public int SpeedIncrementSpan = 10;
        //----------------------------------------------------------------------------------------------------------------------------
        public Ball(Texture2D texture) : base(texture) 
        {
            Speed.X = GetStartSpeedX();
            Speed.Y = GetStartSpeedY();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 GetStartPosition()
        {
            return new Vector2(Pong.ScreenWidth / 2 - texture.Width / 2, Pong.ScreenHeight / 2 - texture.Height / 2);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public float GetStartSpeedX()
        {
            return Pong.Random.Next(1, 10) <= 5 ? -5 : 5;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public float GetStartSpeedY()
        {
            return Pong.Random.Next(1, 5) * (Pong.Random.Next(1, 10) <= 5 ? -1 : 1);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (startPosition == null)
            {
                startPosition = Position;
                startSpeed = Speed;

                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) { isPlaying = true; }
                
            if (!isPlaying) { return; }
                
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > SpeedIncrementSpan) { Speed.X++; Speed.Y++; timer = 0; }

            foreach (var sprite in sprites)
            {
                if (sprite == this) { continue; }

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) { this.Velocity.X = -this.Velocity.X; }
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite)) { this.Velocity.X = -this.Velocity.X; }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) { this.Velocity.Y = -this.Velocity.Y; }
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)) { this.Velocity.Y = -this.Velocity.Y; }
                    
            }

            if (Position.Y <= 0 || Position.Y + texture.Height >= Pong.ScreenHeight) { Velocity.Y = -Velocity.Y; }

            if (Position.X <= 0) { Score.ScoreTwo++; Restart(); }

            if (Position.X + texture.Width >= Pong.ScreenWidth) { Score.ScoreOne++;  Restart(); }

            Position += Velocity * Speed;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void Restart()
        {
            var direction = Pong.Random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    Velocity = new Vector2(1, 1);
                    break;
                case 1:
                    Velocity = new Vector2(1, -1);
                    break;
                case 2:
                    Velocity = new Vector2(-1, -1);
                    break;
                case 3:
                    Velocity = new Vector2(-1, 1);
                    break;
            }

            Position = (Vector2)startPosition;
            Speed = (Vector2)startSpeed;
            timer = 0;
            isPlaying = false;
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
