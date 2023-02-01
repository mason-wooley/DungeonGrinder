using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGrinder {
    class GameFrameHandler : IDrawable, IUpdateable {
        private readonly Game game;
        private readonly SpriteBatch spriteBatch;
        private readonly List<GameFrame> frames;

        public GameFrameHandler(Game game, SpriteBatch spriteBatch) {
            this.game = game;
            this.spriteBatch = spriteBatch;

            // Frames are added on load
            frames = new List<GameFrame>();
        }

        int IDrawable.DrawOrder => throw new NotImplementedException();

        bool IDrawable.Visible => throw new NotImplementedException();

        bool IUpdateable.Enabled => throw new NotImplementedException();

        int IUpdateable.UpdateOrder => throw new NotImplementedException();

        event EventHandler<EventArgs> IDrawable.DrawOrderChanged {
            add {
                throw new NotImplementedException();
            }

            remove {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.VisibleChanged {
            add {
                throw new NotImplementedException();
            }

            remove {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IUpdateable.EnabledChanged {
            add {
                throw new NotImplementedException();
            }

            remove {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IUpdateable.UpdateOrderChanged {
            add {
                throw new NotImplementedException();
            }

            remove {
                throw new NotImplementedException();
            }
        }

        public void AddNewFrame(GameFrame gameFrame) {
            frames.Add(gameFrame);
        }

        public void Draw(GameTime gameTime) {
            foreach (GameFrame frame in frames) {
                frame.Draw(gameTime);
            }

        }

        public void Initialize() {
            Texture2D blankTexture = game.Content.Load<Texture2D>("Textures/blank");
            GameFrame menuFrame = new GameFrame(new Point(100, 100), new Point(300, 200), GameFrame.FrameType.StartupFrame);
            BackgroundComponent backgroundComponent = new BackgroundComponent(menuFrame, blankTexture, spriteBatch, Color.Blue);
            menuFrame.addComponent<BackgroundComponent>(backgroundComponent);
            AddNewFrame(menuFrame);
            
        }

        public void Update(GameTime gameTime) {

        }
    }
}
