using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace PongGame
{
    public class Sprite
    {
        //----------------------------------------------------------------------------------------------------------------------------
        protected Texture2D texture;
        protected Rectangle field;
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Speed;
        public Color Color = Color.White;
        public Input Input;
        //----------------------------------------------------------------------------------------------------------------------------
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            } 
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public Sprite(Texture2D texture, Rectangle field) 
        {
            this.texture = texture;
            this.field = field;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, Position, Color);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        #region Collision
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsTouchingLeft(Sprite sprite)
        {
            return Rectangle.Right + Velocity.X > sprite.Rectangle.Left && Rectangle.Left < sprite.Rectangle.Left && Rectangle.Bottom > sprite.Rectangle.Top && Rectangle.Top < sprite.Rectangle.Bottom;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsTouchingRight(Sprite sprite)
        {
            return Rectangle.Left + Velocity.X < sprite.Rectangle.Right && Rectangle.Right > sprite.Rectangle.Right && Rectangle.Bottom > sprite.Rectangle.Top && Rectangle.Top < sprite.Rectangle.Bottom;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsTouchingTop(Sprite sprite)
        {
            return Rectangle.Bottom + Velocity.Y > sprite.Rectangle.Top && Rectangle.Top < sprite.Rectangle.Top && Rectangle.Right > sprite.Rectangle.Left && Rectangle.Left < sprite.Rectangle.Right;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return Rectangle.Top + Velocity.Y < sprite.Rectangle.Bottom && Rectangle.Bottom > sprite.Rectangle.Bottom && Rectangle.Right > sprite.Rectangle.Left && Rectangle.Left < sprite.Rectangle.Right;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsOutOfTop(float offset = 0)
        {
            return Rectangle.Top <= field.Top + offset;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsOutOfBottom(float offset = 0)
        {
            return Rectangle.Bottom >= field.Bottom + offset;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsOutOfLeft(float offset = 0)
        {
            return Rectangle.Left <= field.Left + offset;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected bool IsOutOfRight(float offset = 0)
        {
            return Rectangle.Right >= field.Right + offset;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
