using GeonBit.UI;
using GeonBit.UI.Entities;
using MagicalLifeAPI.World;
using MagicalLifeClient;
using MagicalLifeServer;
using MagicalLifeServer.Networking;
using MagicalLifeServer.ServerWorld.World_Generation.Generators;
using MagicalLifeSettings.Tables;
using MagicalLifeSettings.Tables.UI.Menus;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.UI.Menus.MainMenu.SubMenus
{
    /// <summary>
    /// The new game menu.
    /// </summary>
    public class NewGameMenu : IMenu
    {
        private readonly UniversalTable UniversalTable = new UniversalTable();

        private TextInput worldWidth = new TextInput(false);
        private TextInput worldHeight = new TextInput(false);

        public Panel GetNewPanel()
        {
            Tuple<int, int> screenSize = this.UniversalTable.GetData();
            Panel ret = new Panel(new Vector2(screenSize.Item1, screenSize.Item2));

            NewGameMenuTable table = new NewGameMenuTable();
            Tuple<int, int> data = table.GetData();

            Vector2 buttonSize = new Vector2(data.Item1, data.Item2);

            Header widthHeader = new Header("World Width");
            Header heightHeader = new Header("World Height");

            Button nextButton = new Button("Next");

            nextButton.OnClick = this.NextButtonClick;

            ret.AddChild(widthHeader);
            ret.AddChild(this.worldWidth);
            ret.AddChild(heightHeader);
            ret.AddChild(this.worldHeight);
            ret.AddChild(nextButton);

            return ret;
        }

        private void NextButtonClick(Entity entity)
        {
            ServerSendRecieve.Initialize(new MagicalLifeAPI.Networking.NetworkSettings(true));
            Server.Load();
            Client.Load();
            Server.StartGame();

            int width = -1;
            bool widthSuccess = int.TryParse(this.worldWidth.Value, out width);
            int length = -1;
            bool lengthSuccess = int.TryParse(this.worldHeight.Value, out length);

            if (widthSuccess && lengthSuccess && width > 0 && length > 0)
            {
                //UserInterface.Active.Clear();
                UserInterface.Active.Root.Visible = false;
                World.Initialize(width, length, new Dirtland());
                //World.Initialize(width, length, new StoneSprinkle());
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }
    }
}
