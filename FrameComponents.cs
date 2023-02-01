using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGrinder {
    class BackgroundComponent : GameFrame.IFrameComponent, IDrawable {
        public GameFrame gameFrame { get; private set; }
        Texture2D backgroundTexture;
        Color backgroundColor;
        public Boolean drawable { get; private set; }
        SpriteBatch spriteBatch;

        public BackgroundComponent(GameFrame gameFrame, Texture2D texture, SpriteBatch spriteBatch) {
            backgroundTexture = texture;
            backgroundColor = Color.Transparent;
            drawable = true;
            this.gameFrame = gameFrame;
            this.spriteBatch = spriteBatch;
        }

        public BackgroundComponent(GameFrame gameFrame, Texture2D texture, SpriteBatch spriteBatch, Color color) {
            backgroundTexture = texture;
            backgroundColor = color;
            drawable = true;
            this.gameFrame = gameFrame;
            this.spriteBatch = spriteBatch;
        }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime) {
            spriteBatch.Draw(backgroundTexture, gameFrame.GetRectangle(), backgroundColor);
        }
    }

    class BorderComponent : GameFrame.IFrameComponent, IDrawable {
        public GameFrame gameFrame { get; private set; }
        Texture2D backgroundTexture;
        Color backgroundColor;
        int borderWidth;
        public Boolean drawable { get; private set; }
        SpriteBatch batch;

        public BorderComponent(GameFrame gameFrame, Texture2D texture, int width) {
            backgroundTexture = texture;
            backgroundColor = Color.Transparent;
            drawable = true;
            this.gameFrame = gameFrame;
            borderWidth = width;
        }

        public BorderComponent(GameFrame gameFrame, Texture2D texture, Color color, int width) {
            backgroundTexture = texture;
            backgroundColor = color;
            drawable = true;
            this.gameFrame = gameFrame;
            borderWidth = width;
        }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime) {
            batch.Draw(backgroundTexture, gameFrame.GetRectangle(), backgroundColor);
        }
    }
}
