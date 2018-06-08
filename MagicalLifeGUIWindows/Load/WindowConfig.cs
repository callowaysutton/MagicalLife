﻿using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Handles configuring the main window.
    /// </summary>
    public class WindowConfig
    {
        /// <summary>
        /// Configures the main window.
        /// </summary>
        /// <param name="game"></param>
        public void ConfigureMainWindow(Game1 game)
        {
            game.Graphics.PreferredBackBufferHeight = MainWindow.Default.ScreenSize.Height;
            game.Graphics.PreferredBackBufferWidth = MainWindow.Default.ScreenSize.Width;

            //Initialize main menu
            //GUI.MainMenu.MainMenu.Initialize();
            //game.IsMouseVisible = true;

            game.Graphics.ToggleFullScreen();
        }
    }
}