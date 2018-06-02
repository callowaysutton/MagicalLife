using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.UI.Menus
{
    /// <summary>
    /// All menus implement this.
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Returns a new GeonBit panel for this menu.
        /// </summary>
        /// <returns></returns>
        Panel GetNewPanel();
    }
}
