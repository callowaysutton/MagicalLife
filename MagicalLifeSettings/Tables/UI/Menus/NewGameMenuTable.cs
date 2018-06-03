using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeSettings.Tables.UI.Menus
{
    public class NewGameMenuTable
    {
        /// <summary>
        /// Button Width, Button Height, Input box width, input box height
        /// </summary>
        private readonly List<Tuple<int, int>> Data = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(400, 100)//1920x1080
        };

        /// <summary>
        /// Button X, Button Width, Button Height, New Game Button Y, Host Game Button Y, Join Game Button Y, Quit Game Button Y
        /// </summary>
        public Tuple<int, int> GetData()
        {
            int index = (int)ResolutionUtil.Resolution;

            if (index < this.Data.Count)
            {
                return this.Data[index];
            }
            else
            {
                throw new ArgumentException("Invalid resolution, or data missing from table");
            }
        }
    }
}
