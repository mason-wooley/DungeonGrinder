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
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, gameFrame.GetRectangle(), backgroundColor);
            spriteBatch.End();
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
            batch.Begin();
            // Left rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X - borderWidth, frameRect.Y - borderWidth, borderWidth, frameRect.Height + borderWidth), borderColor);
            
            // Top rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X, frameRect.Y - borderWidth, frameRect.Width + borderWidth, borderWidth), borderColor);
            
            // Right rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X + frameRect.Width, frameRect.Y, borderWidth, frameRect.Height + borderWidth), borderColor);
            
            // Bottom rectangle
            batch.Draw(borderTexture, new Rectangle(frameRect.X - borderWidth, frameRect.Y + frameRect.Height, frameRect.Width + borderWidth, borderWidth), borderColor);

            batch.End();
        }
    }

    class TextBoxComponent : GameFrame.IFrameComponent, IDrawable {
        public GameFrame gameFrame { get; }
        public String text;

        SpriteBatch batch;
        SpriteFont font;
        Color color;
        Vector2 position;
        Rectangle bounds;
        List<String> outputLines;
        float textLineHight;
        RasterizerState rasterizerState;

        int IDrawable.DrawOrder => throw new NotImplementedException();

        bool IDrawable.Visible => throw new NotImplementedException();

        public TextBoxComponent(GameFrame gameFrame, SpriteBatch batch, String text, SpriteFont font, Color color, Vector2 position) {
            this.gameFrame = gameFrame;
            this.batch = batch;
            this.text = text;
            this.font = font;
            this.color = color;
            this.bounds = gameFrame.GetRectangle();

            rasterizerState = new RasterizerState();
            rasterizerState.ScissorTestEnable = true;

            string[] words = text.Split(" ");
            this.outputLines = new List<String>();
            textLineHight = font.MeasureString("test").Y + 2;
            string temp = "";
            foreach (string word in words) {
                if (font.MeasureString(temp + word + " ").X < this.bounds.Width) {
                    temp += word + " ";
                } else {
                    temp += "\n";
                    outputLines.Add(temp);
                    temp = word + " ";
                }
            }
        }

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

        public void Draw(GameTime gameTime) {
            batch.Begin(rasterizerState: rasterizerState);
            // Copy the original scissor value
            Rectangle originalScissorRect = batch.GraphicsDevice.ScissorRectangle;

            batch.GraphicsDevice.ScissorRectangle = bounds;

            Point framePt = gameFrame.GetRectangle().Location;
            for (int i = 0; i < outputLines.Count; i++) {
                batch.DrawString(font, outputLines[i], new Vector2(framePt.X + position.X, framePt.Y + position.Y + (i * textLineHight)), color);
            }

            batch.End();
        }
    }
}
