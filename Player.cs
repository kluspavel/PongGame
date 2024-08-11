using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    class Player : Sprite
    {
        public Player(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle playField) : base(texture, position, direction, speed, playField)
        {

        }

        private void BoundsScreen()
        {

        }
    }
}
