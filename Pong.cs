using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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

        private Texture2D gamePlan;

        private Ball ball;
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

            gamePlan = Content.Load<Texture2D>(@"Sprites\game_plan");

            ball = new Ball(Content.Load<Texture2D>(@"Sprites\ball"), new Vector2(0, 0), new Vector2(0, 0), 5, playField);
            score = new Score(fontDotGothic, Color.DarkBlue, playField, ball);



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
            ball.Update(gameTime);
            score.Update(gameTime);
            
            base.Update(gameTime);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(gamePlan, new Vector2(0, 0), Color.White);
            ball.Draw(spriteBatch);
            score.Draw(spriteBatch);
            
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
