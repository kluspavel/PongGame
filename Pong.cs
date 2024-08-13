using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace PongGame
{
    // PALKOO GAME PONG
    public class Pong : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private System.Drawing.Size winSize;
        private Rectangle playField;

        private SoundEffect soundTweet;
        private Song songZardax;

        private SpriteFont fontDotGothic;

        private Sprite gamePlan;

        private List<Player> playerList;
        private List<Ball> ballList;

        private Score score;
        //----------------------------------------------------------------------------------------------------------------------------
        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            winSize = new System.Drawing.Size(1280, 720);
            playField = new Rectangle(0, 0, winSize.Width, winSize.Height);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = winSize.Width;
            graphics.PreferredBackBufferHeight = winSize.Height;
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

            fontDotGothic = Content.Load<SpriteFont>(@"Fonts\dot_gothic_16");

            gamePlan = new Sprite(Content.Load<Texture2D>(@"Sprites\game_plan")) { Position= new Vector2(0, 0), };

            Texture2D playerOne = Content.Load<Texture2D>(@"Sprites\player_one");
            Texture2D playerTwo = Content.Load<Texture2D>(@"Sprites\player_two");

            playerList = new List<Player>()
            {
                new(playerOne) { Position = new Vector2(10, winSize.Height / 2 - playerOne.Height / 2), Input = new Input() { Up = Keys.W, Down = Keys.S } },
                new(playerTwo) { Position = new Vector2(winSize.Width - 30, winSize.Height / 2 - playerTwo.Height / 2), Input = new Input() { Up = Keys.Up, Down = Keys.Down } },
            };

            Texture2D ballOne = Content.Load<Texture2D>(@"Sprites\ball");
            Texture2D ballTwo = Content.Load<Texture2D>(@"Sprites\ball");

            ballList = new List<Ball>()
            {
                new(ballOne) { },
            };

            //playerOne = new Player(Content.Load<Texture2D>(@"Sprites\player_one"), new Vector2(10, 0), new Vector2(0, 0), 5, playField);
            //playerTwo = new Player(Content.Load<Texture2D>(@"Sprites\player_one"), new Vector2(1280 - 20 - 10, 0), new Vector2(0, 0), 5, playField);
            //ball = new Ball(Content.Load<Texture2D>(@"Sprites\ball"), new Vector2(0, 0), new Vector2(0, 0), 5, playField);
            //score = new Score(fontDotGothic, Color.DarkBlue, playField, ball);




            //_playerOne = Content.Load<Texture2D>(@"Sprites\player_one");
            //_playerTwo = Content.Load<Texture2D>(@"Sprites\player_two");


            MediaPlayer.IsRepeating = true;
            PlaySong(songZardax);


        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

            // TODO: Add your update logic here

            foreach (var player in playerList) 
            {
                player.Update();
            }

            foreach (var ball in ballList)
            {
                ball.Update();
            }



            //playerOne.Update(gameTime);
            //playerTwo.Update(gameTime);
            //ball.Update(gameTime);
            //score.Update(gameTime);

            base.Update(gameTime);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            gamePlan.Draw(spriteBatch);

            foreach (var player in playerList)
            {
                player.Draw(spriteBatch);
            }

            foreach (var ball in ballList)
            {
                ball.Draw(spriteBatch);
            }








            //playerOne.Draw(spriteBatch);
            //playerTwo.Draw(spriteBatch);
            //ball.Draw(spriteBatch);
            //score.Draw(spriteBatch);

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
