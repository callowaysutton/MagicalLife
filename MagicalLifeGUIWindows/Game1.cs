using GeonBit.UI;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.External_Type_Serialization;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.Load;
using MagicalLifeGUIWindows.UI.Menus.MainMenu;
using MagicalLifeSettings.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalLifeGUIWindows
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static ContentManager AssetManager { get; set; }

        // graphics and spritebatch
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        /// Game constructor.
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Game1.AssetManager = this.Content;
            UniversalEvents.GameExit += this.UniversalEvents_GameExit;
        }

        private void UniversalEvents_GameExit(object sender, System.EventArgs e)
        {
            this.Exit();
        }

        /// Allows the game to perform any initialization it needs to before starting to run.
        /// here we create and init the UI manager.
        protected override void Initialize()
        {
            UserInterface.Initialize(this.Content, BuiltinThemes.hd);
            UserInterface.Active.AddEntity(new MainMenu().GetNewPanel());

            // call base initialize function
            base.Initialize();
        }

        /// LoadContent will be called once per game and is the place to load.
        /// here we initialize the spriteBatch (this is code you probably already have).
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Loader load = new Loader();
            string msg = string.Empty;

            load.LoadAll(ref msg, new List<Assembly>
                {
                    Assembly.GetAssembly(typeof(World)),
                    Assembly.GetAssembly(typeof(Game1)),
                    Assembly.GetAssembly(typeof(PointTeacher))
                });

            WindowConfig winConfig = new WindowConfig();
            winConfig.ConfigureMainWindow(this);
        }

        /// Allows the game to run logic such as updating the world.
        /// here we call the UI manager update() function to update the UI.
        protected override void Update(GameTime gameTime)
        {
            // GeonBit.UIL update UI manager
            UserInterface.Active.Update(gameTime);

            // call base update
            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        /// here we call the UI manager draw() function to render the UI.
        protected override void Draw(GameTime gameTime)
        {
            // clear buffer
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // GeonBit.UI: draw UI using the spriteBatch you created above
            UserInterface.Active.Draw(SpriteBatch);

            // call base draw function
            base.Draw(gameTime);
        }
    }
}