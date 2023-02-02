using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGrinder {
    public class Game1 : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameFrameHandler gameFrameHandler;
        public Texture2D backgroundTexture;
        public Game1() {
            graphics = new GraphicsDeviceManager(this);
  
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            GraphicsDevice.ScissorRectangle = new Rectangle(0, 0, 1200, 1200);
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameFrameHandler = new GameFrameHandler(this, spriteBatch);
            gameFrameHandler.Initialize();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameFrameHandler.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            gameFrameHandler.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
