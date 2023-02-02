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
            // TODO: This can be different textures for more complex design
            Texture2D blankTexture = game.Content.Load<Texture2D>("Textures/blank");

            SpriteFont font = game.Content.Load<SpriteFont>("Fonts/JupiteroidRegular");

            // Add a GameFrame for the menu with a blue background
            GameFrame menuFrame = new GameFrame(new Point(100, 100), new Point(300, 200), GameFrame.FrameType.StartupFrame);

            BackgroundComponent backgroundComponent = new BackgroundComponent(menuFrame, blankTexture, spriteBatch, Color.DarkSeaGreen);
            menuFrame.addComponent<BackgroundComponent>(backgroundComponent);

            BorderComponent borderComponent = new BorderComponent(menuFrame, blankTexture, spriteBatch, Color.Olive, 5);
            menuFrame.addComponent<BorderComponent>(borderComponent);

            TextBoxComponent textBoxComponent = new TextBoxComponent(menuFrame, spriteBatch, "What the fuck did you just fucking say about me, you little bitch? I'll have you know I graduated top of my class in the Navy Seals, and I've been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I'm the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You're fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that's just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little \"clever\" comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn't, you didn't, and now you're paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You're fucking dead, kiddo.",
                font, Color.OldLace, new Vector2(50, 50));
            menuFrame.addComponent<TextBoxComponent>(textBoxComponent);

            AddNewFrame(menuFrame);
        }

        public void Update(GameTime gameTime) {

        }
    }
}
