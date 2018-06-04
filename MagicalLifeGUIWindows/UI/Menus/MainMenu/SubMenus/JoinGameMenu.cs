using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI.Entities;
using MagicalLifeClient;
using MagicalLifeNetworking.Client;
using MagicalLifeSettings.Tables;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.UI.Menus.MainMenu.SubMenus
{
    public class JoinGameMenu : IMenu
    {
        private readonly UniversalTable UniversalTable = new UniversalTable();

        private TextInput IPInput = new TextInput(false);
        private TextInput PortInput = new TextInput(false);

        public Panel GetNewPanel()
        {
            Tuple<int, int> screenSize = this.UniversalTable.GetData();
            Panel ret = new Panel(new Vector2(screenSize.Item1, screenSize.Item2));

            Header IPHeader = new Header("Host IP");
            Header PortHeader = new Header("Port");

            Button ConnectButton = new Button("Connect");
            ConnectButton.OnClick = this.ConnectButtonClick;

            ret.AddChild(IPHeader);
            ret.AddChild(this.IPInput);
            ret.AddChild(PortHeader);
            ret.AddChild(this.PortInput);
            ret.AddChild(ConnectButton);

            return ret;

        }

        private void ConnectButtonClick(Entity entity)
        {
            bool success = int.TryParse(this.PortInput.Value, out int port);

            if (success)
            {

                ClientSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(this.IPInput.Value, port));
                Client.Load();
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }
    }
}
