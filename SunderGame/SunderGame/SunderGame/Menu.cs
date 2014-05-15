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

namespace SunderGame
{
    class Menu
    {
        GraphicsDeviceManager graphics;

        enum GameState
        {
            MainMenu,
            HelpMenu,
            InGame,
            Quit
        }
        GameState currentGameState = GameState.MainMenu;

        int screenWidth, screenHeight;

        Rectangle playButton, helpButton, exitButton, mouseRect;

        public Menu(GraphicsDeviceManager graphics, Rectangle mouseRect, int screenWidth, int screenHeight)
        {
            this.graphics = graphics;
            this.mouseRect = mouseRect;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;


        }

        public void setButtons()
        {
            playButton = new Rectangle(
                graphics.GraphicsDevice.Viewport.Width-graphics.GraphicsDevice.Viewport.Width/3,
                graphics.GraphicsDevice.Viewport.Height-graphics.GraphicsDevice.Viewport.Height/2,
                screenWidth/4,
                screenHeight/12);
        }

        public void checkMenuActions()
        {
            KeyboardState kb = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (mouseRect.Intersects(playButton) && mouse.LeftButton == ButtonState.Pressed)
            {
                currentGameState = GameState.Quit;
            }
        }

        public void drawButtons(List<Texture2D> menuTextures, SpriteBatch sb)
        {
            switch(currentGameState)
            {
                case GameState.MainMenu:
                    {

                        sb.Draw(menuTextures[0], playButton, Color.Chartreuse);

                        break;
                    }
                case GameState.Quit:
                    {
                        this.Exit();
                    }
                   
            }

        }
    }
}
