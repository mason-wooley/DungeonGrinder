﻿using Microsoft.Xna.Framework;
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
        Texture2D borderTexture;
        Color borderColor;
        int borderWidth;
        public Boolean drawable { get; private set; }
        SpriteBatch batch;
        Rectangle frameRect;

        public BorderComponent(GameFrame gameFrame, Texture2D texture, SpriteBatch spriteBatch, Color color, int width) {
            borderTexture = texture;
            borderColor = color;
            drawable = true;
            this.gameFrame = gameFrame;
            borderWidth = width;
            batch = spriteBatch;
            frameRect = gameFrame.GetRectangle();
        }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime) {
            // Left rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X, frameRect.Y, borderWidth, frameRect.Height + borderWidth), borderColor);
            
            // Top rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X, frameRect.Y, frameRect.Width + borderWidth, borderWidth), borderColor);
            
            // Right rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X + frameRect.Width, frameRect.Y, borderWidth, frameRect.Height + borderWidth), borderColor);
            
            // Bottom rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X, frameRect.Y + frameRect.Height, frameRect.Width + borderWidth, borderWidth), borderColor);
        }
    }
}
