using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeSettings.Tables.UI.Menus
{
    /// <summary>
    /// Holds some GUI data for the main menu.
    /// </summary>
    public class MainMenuTable
    {
        /// <summary>
        /// Button X, Button Width, Button Height, New Game Button Y, Host Game Button Y, Join Game Button Y, Quit Game Button Y
        /// </summary>
        private readonly List<Tuple<int, int, int, int, int, int, int>> Data = new List<Tuple<int, int, int, int, int, int, int>>()
        {
            new Tuple<int, int, int, int, int, int, int>(20, 400, 100, 20, 120, 240, 360)//1920x1080
        };

        /// <summary>
        /// Button X, Button Width, Button Height, New Game Button Y, Host Game Button Y, Join Game Button Y, Quit Game Button Y
        /// </summary>
        public Tuple<int, int, int, int, int, int, int> GetData()
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
