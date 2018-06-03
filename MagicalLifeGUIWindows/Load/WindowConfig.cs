using MagicalLifeSettings;
using MagicalLifeSettings.Storage;

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
            int width;
            int height;

            switch (ResolutionUtil.Resolution)
            {
                default:
                    width = 1920;
                    height = 1080;
                    break;
            }

            game.Graphics.PreferredBackBufferHeight = height;
            game.Graphics.PreferredBackBufferWidth = width;

            //Initialize main menu
            //GUI.MainMenu.MainMenu.Initialize();
            //game.IsMouseVisible = true;

            game.Graphics.ToggleFullScreen();
        }
    }
}