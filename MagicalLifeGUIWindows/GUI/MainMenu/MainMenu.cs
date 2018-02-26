﻿using System.Runtime.CompilerServices;
using MagicalLifeGUIWindows.GUI.MainMenu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Holds the controls for the main menu.
    /// </summary>
    public static class MainMenu
    {
        static MainMenu()
        {
        }

        public static void Initialize()
        {
            //NewGameButton = new MonoButton("MenuButton", GetNewGameButtonLocation(), "New Game");
            NewGameButton = new NewGameButton();
        }

        /// <summary>
        /// Toggles the main menu.
        /// </summary>
        public static void ToggleMainMenu()
        {
            if (NewGameButton.Visible)
            {
                NewGameButton.Visible = false;
            }
            else
            {
                NewGameButton.Visible = true;
            }
        }

        public static NewGameButton NewGameButton { get; private set; }
    }
}