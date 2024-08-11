using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    class Sprite
    {
        //----------------------------------------------------------------------------------------------------------------------------
        protected Texture2D texture;

        protected Vector2 position;
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected Vector2 direction;
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected float speed;
        //----------------------------------------------------------------------------------------------------------------------------
        protected Rectangle playField;
        //----------------------------------------------------------------------------------------------------------------------------
        public Sprite(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle playField)
        {
            this.texture = texture;
            this.position = position;
            this.direction = direction;
            this.speed = speed;
            this.playField = playField;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Update(GameTime gameTime)
        {
            position += direction;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
