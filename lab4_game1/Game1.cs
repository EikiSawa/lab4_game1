using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lab4_game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D circle;
        int frame, framePerSec, frame_Coke_Faceway;
        float totalElapsed, timePerFrame;
        Vector2 Coke_position, Coke_speed = Vector2.Zero;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Coke_speed.X = 3;
            Coke_position = new Vector2(250, 250);
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            circle = Content.Load<Texture2D>("CoketumpBreathe2Way");
            framePerSec = 2;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            Coke_position += Coke_speed;

            if (Coke_position.X  <= 100 || Coke_position.X >= 600)
            {
                Coke_speed = -1 * Coke_speed;
            }

            if (Coke_speed.X >0)
            {
                frame_Coke_Faceway = 1;
            }
            else frame_Coke_Faceway = 0;


            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(circle, Coke_position, new Rectangle(frame * 51, 63 * frame_Coke_Faceway, 51, 63), Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % 3;
                totalElapsed -= timePerFrame;
            }
        }
    }
}
