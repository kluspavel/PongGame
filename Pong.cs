using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using PongGame.Sprites;
using PongGame.Models;


namespace PongGame
{
    // PALKOO GAME PONG
    public class Pong : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Random Random;

        private Rectangle playField;

        private SoundEffect soundTweet;
        private Song songZardax;

        private SpriteFont fontDotGothic;
        private SpriteFont fontText;

        private Sprite gamePlan;

        private List<Player> playerList;
        private List<Ball> ballList;

        private Score score;
        private Info info;
        private List<Sprite> spriteList;
        //----------------------------------------------------------------------------------------------------------------------------
        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenWidth = graphics.PreferredBackBufferWidth = 1280;
            ScreenHeight = graphics.PreferredBackBufferHeight = 720;
            Random = new Random();
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            soundTweet = Content.Load<SoundEffect>(@"Sounds\sound_tweet");
            songZardax = Content.Load<Song>(@"Sounds\sound_zardax");

            score = new Score(Content.Load<SpriteFont>(@"Fonts\dot_gothic_16"));
            info = new Info(Content.Load<SpriteFont>(@"Fonts\text_font"));

            var gameplan = Content.Load<Texture2D>(@"Sprites\game_plan");
            var playerOne = Content.Load<Texture2D>(@"Sprites\player_one");
            var playerTwo = Content.Load<Texture2D>(@"Sprites\player_two");
            var ball = Content.Load<Texture2D>(@"Sprites\ball");

            spriteList = new List<Sprite>()
            {
                new Sprite(gameplan),
                new Player(playerOne)
                {
                    Position = new Vector2(10, ScreenHeight / 2 -  playerOne.Height / 2),
                    Input = new Input() { Up = Keys.W, Down = Keys.S }
                },
                new Player(playerTwo)
                {
                    Position = new Vector2(ScreenWidth - playerTwo.Width - 10, ScreenHeight / 2 -  playerTwo.Height / 2),
                    Input = new Input() { Up = Keys.Up, Down = Keys.Down }
                },
                new Ball(ball){ Score = score, Info = info },
            };

            MediaPlayer.IsRepeating = true;
            PlaySong(songZardax);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

            // TODO: Add your update logic here

            foreach(var sprite in spriteList)
            {
                sprite.Update(gameTime, spriteList);
            }

            base.Update(gameTime);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (var sprite in spriteList)
            {
                sprite.Draw(spriteBatch);
            }

            score.Draw(spriteBatch);
            info.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public void PlaySong(Song song)
        {
            // Nehraje již ta samá hudba?
            if (MediaPlayer.Queue.ActiveSong != song)
            {
                MediaPlayer.Play(song);
            } 
        }
    }
}
