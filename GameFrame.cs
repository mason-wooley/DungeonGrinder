using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGrinder {
    public class GameFrame {
        public Point Position;
        public Point Size;
        public FrameType Type;

        public enum FrameType {
            StartupFrame
        }

        public interface IFrameComponent {
            GameFrame gameFrame { get; }
        }

        private Rectangle frameRect;
        private Vector2 anchorPosition;

        private List<IFrameComponent> components;
        private List<IDrawable> drawables;
        private List<IUpdateable> updateables;

        public GameFrame(Point Position, Point Size, FrameType Type) {
            this.Position = Position;
            this.Size = Size;
            this.Type = Type;

            components = new List<IFrameComponent>();
            drawables = new List<IDrawable>();
            updateables = new List<IUpdateable>();

            frameRect = new Rectangle(this.Position, this.Size);
        }

        public void addComponent<T>(T component) {
            if (component is IDrawable) {
                drawables.Add((IDrawable)component);
            } else if (component is IUpdateable) {
                updateables.Add((IUpdateable)component);
            }

            components.Add((IFrameComponent)component);
        }

        public void Draw(GameTime gameTime) {
            foreach (IDrawable component in drawables) {
                component.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime) {
            foreach (IUpdateable component in updateables) {
                component.Update(gameTime);
            }
        }

        public Rectangle GetRectangle() {
            return frameRect;
        }
    }
}
