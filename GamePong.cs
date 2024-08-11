using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    public class GamePong : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public int _winWidth = 1280, _winHeight = 720;

        private SoundEffect _soundTweet;
        public Song _soundZardax;

        private Texture2D _playerOne, _playerTwo, _gamePlan, _ball;
        public SpriteFont _fontPlay, _fontAnton, _fontDotGothic;

        public KeyboardState _keyState, _lastKey;

        public float _playerOneY = 20, _playerTwoY = 20, _ballX = 630, _ballY = 350;
        public float _playerOneSpeed = 10, _playerTwoSpeed = 10, _ballSpeedX = 10, _ballSpeedY = 5;

        public int _playerOneScore = 0, _playerTwoScore = 0;

        private Rectangle _playField;

        Ball _ballonek;

        public GamePong()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _playField = new Rectangle(10, 15, _graphics.PreferredBackBufferWidth - 10, _graphics.PreferredBackBufferHeight - 15);

            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = _winWidth;
            _graphics.PreferredBackBufferHeight = _winHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _soundTweet = Content.Load<SoundEffect>(@"Sounds\sound_tweet");
            _soundZardax = Content.Load<Song>(@"Sounds\sound_zardax");

            // TODO: use this.Content to load your game content here

            _playerOne = Content.Load<Texture2D>(@"Sprites\player_one");
            _playerTwo = Content.Load<Texture2D>(@"Sprites\player_two");
            _gamePlan = Content.Load<Texture2D>(@"Sprites\game_plan");
            _ball = Content.Load<Texture2D>(@"Sprites\ball");

            _fontPlay = Content.Load<SpriteFont>(@"Fonts\play_bold");
            _fontAnton = Content.Load<SpriteFont>(@"Fonts\anton");
            _fontDotGothic = Content.Load<SpriteFont>(@"Fonts\dot_gothic_16");

            _ballonek = new Ball(_ball, new Vector2(0, 0), new Vector2(0, 0), 5, _playField);

            MediaPlayer.IsRepeating = true;
            SwitchSong(_soundZardax);

            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _lastKey = _keyState;
            _keyState = Keyboard.GetState();

            if (_keyState.IsKeyDown(Keys.Enter) && _lastKey.IsKeyUp(Keys.Enter))
                _soundTweet.Play();

            if (_keyState.IsKeyDown(Keys.W))
            {
                _playerOneY -= _playerOneSpeed;

                if (_playerOneY < 15)
                {
                    _playerOneY = 15;
                }
            }

            if (_keyState.IsKeyDown(Keys.S))
            {
                _playerOneY += _playerOneSpeed;

                if (_playerOneY > 720 - 15 - 120)
                {
                    _playerOneY = 720 - 15 - 120;
                }
            }

            if (_keyState.IsKeyDown(Keys.Up))
            {
                _playerTwoY -= _playerOneSpeed;

                if (_playerTwoY < 15)
                {
                    _playerTwoY = 15;
                }
            }

            if (_keyState.IsKeyDown(Keys.Down))
            {
                _playerTwoY += _playerOneSpeed;

                if (_playerTwoY > 720 - 15 - 120)
                {
                    _playerTwoY = 720 - 15 - 120;
                }
            }

            _ballX += _ballSpeedX;
            _ballY += _ballSpeedY;

            if (_ballX > 1280 - 20)
            {
                _ballSpeedX = -5;
                _ballX = 1280 - 20;
                _playerOneScore++;
            }

            if (_ballX < 10)
            {
                _ballSpeedX = 5;
                _ballX = 10;
                _playerTwoScore++;
            }

            if (_ballY > 720 - 20 - 15)
            {
                _ballSpeedY = -5;
                _ballY = 720 - 20 - 15;
            }

            if (_ballY < 15)
            {
                _ballSpeedY = 5;
                _ballY = 15;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(_gamePlan, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(_playerOne, new Vector2(10, _playerOneY), Color.Blue);
            _spriteBatch.Draw(_playerTwo, new Vector2(1250, _playerTwoY), Color.Red);
            _spriteBatch.Draw(_ball, new Vector2(_ballX, _ballY), Color.White);
            _spriteBatch.DrawString(_fontDotGothic, _playerOneScore.ToString().PadLeft(2, '0'), new Vector2(566, 10), Color.Gray);
            _spriteBatch.DrawString(_fontDotGothic, _playerTwoScore.ToString().PadLeft(2, '0'), new Vector2(662, 10), Color.Gray);
            _spriteBatch.End();

            base.Draw(gameTime);
        }







        public void SwitchSong(Song song)
        {
            // Nehraje již ta samá hudba?
            if (MediaPlayer.Queue.ActiveSong != song)
                MediaPlayer.Play(song);
        }
    }
}
