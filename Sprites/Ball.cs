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
        public Score Score;
        public int SpeedIncrementSpan = 10;
        //----------------------------------------------------------------------------------------------------------------------------
        public Info Info;
        //----------------------------------------------------------------------------------------------------------------------------
        public Ball(Texture2D texture) : base(texture) 
        {
            Restart();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 GetStartPosition()
        {
            return new Vector2(Pong.ScreenWidth / 2 - texture.Width / 2, Pong.ScreenHeight / 2 - texture.Height / 2);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public static float GetStartSpeedX()
        {
            return Pong.Random.Next(1, 10) <= 5 ? -5 : 5;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public static float GetStartSpeedY()
        {
            return Pong.Random.Next(1, 5) * (Pong.Random.Next(1, 10) <= 5 ? -1 : 1);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) { isPlaying = true; }
                
            if (!isPlaying) { return; }
                
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > SpeedIncrementSpan) 
            {
                Info.actualSpeed++;
                if (this.Velocity.X > 0) { this.Velocity.X += Speed; }
                if (this.Velocity.X < 0) { this.Velocity.X -= Speed; }
                if (this.Velocity.Y > 0) { this.Velocity.Y += Speed; }
                if (this.Velocity.Y < 0) { this.Velocity.Y -= Speed; }
                timer = 0; 
            }

            foreach (var sprite in sprites)
            {
                if (sprite == this) { continue; }

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) { this.Velocity.X *= -1; Position.X = Pong.ScreenWidth - 10 - texture.Width - sprite.Rectangle.Width; Info.bouceCount++; }
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite)) { this.Velocity.X *= -1; Position.X = 10 + sprite.Rectangle.Width; Info.bouceCount++; }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) { this.Velocity.Y *= -1; Info.bouceCount++; }
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)) { this.Velocity.Y *= -1; Info.bouceCount++; }
            }

            if (Position.Y <= 15 || Position.Y >= Pong.ScreenHeight - texture.Height - 15) { Velocity.Y *= -1; }

            if (Position.X <= 0) { Score.ScoreTwo++; Restart(); InfoClear(); }

            if (Position.X + texture.Width >= Pong.ScreenWidth) { Score.ScoreOne++;  Restart(); InfoClear(); }

            Position += Velocity;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void Restart()
        {
            Position = GetStartPosition();
            Velocity.X = GetStartSpeedX();
            Velocity.Y = GetStartSpeedY();
            Speed = 1;
            timer = 0;
            isPlaying = false;
            
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void InfoClear()
        {
            Info.bouceCount = 0;
            Info.actualSpeed = (int)Speed;
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
