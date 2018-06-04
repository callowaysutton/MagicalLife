using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI;
using GeonBit.UI.Entities;
using MagicalLifeAPI.Networking;
using MagicalLifeServer.Networking;
using MagicalLifeSettings.Tables;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.UI.Menus.MainMenu.SubMenus
{
    /// <summary>
    /// The host game menu.
    /// </summary>
    public class HostGameMenu : IMenu
    {
        private readonly UniversalTable UniversalTable = new UniversalTable();

        /// <summary>
        /// Where the user inputs the port to host the server on.
        /// </summary>
        private TextInput PortInput = new TextInput(false);

        public Panel GetNewPanel()
        {
            Tuple<int, int> screenSize = this.UniversalTable.GetData();
            Panel ret = new Panel(new Vector2(screenSize.Item1, screenSize.Item2));

            Button next = new Button("Start Host");
            next.OnClick = this.StartHostButtonClick;

            ret.AddChild(this.PortInput);
            ret.AddChild(next);

            return ret;
        }

        private void StartHostButtonClick(Entity entity)
        {
            bool success = int.TryParse(this.PortInput.Value, out int port);

            if (success)
            {
                ServerSendRecieve.Initialize(new NetworkSettings(port));
                UserInterface.Active.AddEntity(new NewGameMenu().GetNewPanel());
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }
    }
}
