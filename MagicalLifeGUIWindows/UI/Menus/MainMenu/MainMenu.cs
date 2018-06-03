using GeonBit.UI;
using GeonBit.UI.Entities;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.UI.Menus.MainMenu.SubMenus;
using MagicalLifeSettings.Tables;
using MagicalLifeSettings.Tables.UI.Menus;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.UI.Menus.MainMenu
{
    /// <summary>
    /// A main menu.
    /// </summary>
    public class MainMenu : IMenu
    {
        private readonly UniversalTable UniversalTable = new UniversalTable();

        public MainMenu()
        {

        }

        public Panel GetNewPanel()
        {
            Tuple<int, int> screenSize = this.UniversalTable.GetData();
            Panel ret = new Panel(new Vector2(screenSize.Item1, screenSize.Item2));
            MainMenuTable table = new MainMenuTable();
            Tuple<int, int> data = table.GetData();

            Vector2 buttonSize = new Vector2(data.Item1, data.Item2);

            Button newGame = new Button("New Game");
            Button hostGame = new Button("Host Game");
            Button joinGame = new Button("Join Game");
            Button quit = new Button("Quit");

            newGame.Size = buttonSize;
            hostGame.Size = buttonSize;
            joinGame.Size = buttonSize;
            quit.Size = buttonSize;

            newGame.OnClick = NewGameButtonClick;
            hostGame.OnClick = HostGameButtonClick;
            joinGame.OnClick = JoinGameButtonClick;
            quit.OnClick = QuitButtonClick;

            ret.AddChild(newGame);
            ret.AddChild(hostGame);
            ret.AddChild(joinGame);
            ret.AddChild(quit);

            return ret;
        }

        private void QuitButtonClick(Entity entity)
        {
            UniversalEvents.GameExitHandler();
        }

        private void NewGameButtonClick(Entity entity)
        {
            UserInterface.Active.AddEntity(new NewGameMenu().GetNewPanel());
        }

        private void HostGameButtonClick(Entity entity)
        {

        }

        private void JoinGameButtonClick(Entity entity)
        {

        }
    }
}
