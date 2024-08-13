using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    public class Sprite
    {
        //----------------------------------------------------------------------------------------------------------------------------
        private Texture2D texture;
        //----------------------------------------------------------------------------------------------------------------------------
        public Vector2 Position;
        //----------------------------------------------------------------------------------------------------------------------------
        public Sprite(Texture2D texture) 
        {
            this.texture = texture;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Update()
        {

        }
        //----------------------------------------------------------------------------------------------------------------------------
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
