using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace SunderGame
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch nowDraw;
        MouseState mouse;

        Rectangle mouseRect, playButton;

        bool onCharSelect;

        enum GameState
        {
            MainMenu,
            HelpMenu,
            CharSelectMenu,
            InGame,
            Quit
        }
        GameState currentGameState = GameState.MainMenu;

        int resolutionWidth, resolutionHeight;
        List<Texture2D> buttonTextures;

        Menu mainMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.IsFullScreen = true;
            IsMouseVisible = true;
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

            onCharSelect = false;

            resolutionWidth = graphics.PreferredBackBufferWidth;
            resolutionHeight = graphics.PreferredBackBufferHeight;

            playButton = new Rectangle(
                graphics.GraphicsDevice.Viewport.Width - graphics.GraphicsDevice.Viewport.Width / 3,
                graphics.GraphicsDevice.Viewport.Height - graphics.GraphicsDevice.Viewport.Height / 2,
                resolutionWidth / 4,
                resolutionHeight / 20);

            buttonTextures = new List<Texture2D>();

            mainMenu = new Menu(graphics, resolutionWidth, resolutionHeight);
            mainMenu.setButtons();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            buttonTextures.Add(Content.Load<Texture2D>("playButton"));
            nowDraw = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            KeyboardState kb = Keyboard.GetState();
            mouse = Mouse.GetState();
            mouseRect = new Rectangle(mouse.X, mouse.Y, 10, 10);

            //mainMenu.checkMenuActions(kb, mouse);

            if(kb.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if(mouseRect.Intersects(playButton) && mouse.LeftButton==ButtonState.Pressed)
            {
                currentGameState = GameState.CharSelectMenu;
                onCharSelect = true;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        public void exitGame()
        {
            this.Exit();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            nowDraw.Begin();
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    {
                        nowDraw.Draw(buttonTextures[0], playButton, Color.White);
                        break;
                    }


                case GameState.CharSelectMenu:
                    {
                        nowDraw.Draw(buttonTextures[0], new Rectangle(10,10,200,500), Color.White);
                        break;
                    }
            }

            nowDraw.Draw(buttonTextures[0], mouseRect, Color.White);

            if (onCharSelect)
                GraphicsDevice.Clear(Color.Chartreuse);
            //mainMenu.drawButtons(buttonTextures, nowDraw);

            nowDraw.End();

            base.Draw(gameTime);
        }
    }
}
