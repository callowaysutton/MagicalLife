using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Rendering.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace MagicalLifeGUIWindows.Rendering
{
    /// <summary>
    /// Handles drawing the entire screen.
    /// </summary>
    public static class RenderingPipe
    {
        /// <summary>
        /// The standard size of the tiles.
        /// </summary>
        public static readonly Microsoft.Xna.Framework.Point tileSize = Tile.GetTileSize();

        public static readonly Rectangle FullScreenWindow = new Rectangle(new Point(0, 0), new Point(RenderUtils.GetScreenResolution().X, RenderUtils.GetScreenResolution().Y));

        /// <summary>
        /// The standard color mask to apply to all tiles.
        /// </summary>
        public static readonly Color colorMask = Color.White;

        /// <summary>
        /// The x offset of the view due to the player moving the camera around the map.
        /// </summary>
        public static int XViewOffset = 0;

        /// <summary>
        /// The y offset of the view due to the player moving the camera around the map.
        /// </summary>
        public static int YViewOffset = 0;

        /// <summary>
        /// Draws the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawScreen(ref SpriteBatch spBatch)
        {
            if (World.MainWorld != null)
            {
                MapRenderer.DrawMap(ref spBatch);
            }

            DrawGUI(ref spBatch);

            //DrawMouseLocation(ref spBatch);
        }

        /// <summary>
        /// Draws the GUI onto the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        private static void DrawGUI(ref SpriteBatch spBatch)
        {
            DrawContainers(ref spBatch);
        }

        private static void DrawContainers(ref SpriteBatch spBatch)
        {
            foreach (GUIContainer item in Enumerable.Reverse(BoundHandler.GUIWindows))
            {
                if (item.Visible)
                {
                    spBatch.Draw(item.Image, item.DrawingBounds, colorMask);

                    foreach (GUIElement control in item.Controls)
                    {
                        if (control.Visible)
                        {
                            switch (control)
                            {
                                default:
                                    //Should probably send out a event or something, to allow someone else to render it.
                                    //TODO:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}