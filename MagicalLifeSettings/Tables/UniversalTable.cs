using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeSettings.Tables
{
    /// <summary>
    /// Some shared data
    /// </summary>
    public class UniversalTable
    {
        /// <summary>
        /// ScreenWidth, ScreenHeight
        /// </summary>
        private readonly List<Tuple<int, int>> Data = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(1920, 1080)
        };

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
