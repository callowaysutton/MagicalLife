using GeonBit.UI;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.External_Type_Serialization;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.Load;
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
        //public GraphicsDeviceManager Graphics { get; set; }
        //public SpriteBatch SpriteBatch;

        public static ContentManager AssetManager { get; set; }

        //public Game1()
        //{
        //    this.Graphics = new GraphicsDeviceManager(this);
        //    this.Content.RootDirectory = "Content";
        //    Game1.AssetManager = this.Content;
        //    UniversalEvents.GameExit += this.UniversalEvents_GameExit;
        //    Graphics.HardwareModeSwitch = false;
        //}

        //private void UniversalEvents_GameExit(object sender, System.EventArgs e)
        //{
        //    this.Exit();
        //}

        ///// <summary>
        ///// Allows the game to perform any initialization it needs to before starting to run.
        ///// This is where it can query for any required services and load any non-graphic
        ///// related content.  Calling base.Initialize will enumerate through any components
        ///// and initialize them as well.
        ///// </summary>
        //protected override void Initialize()
        //{
        //    UserInterface.Initialize(AssetManager, BuiltinThemes.hd);
        //    UserInterface.Active.UseRenderTarget = true;

        //    Universal.Default.GameHasRunBefore = true;

        //    base.Initialize();
        //}

        ///// <summary>
        ///// LoadContent will be called once per game and is the place to load
        ///// all of your content.
        ///// </summary>
        //protected override void LoadContent()
        //{
        //    // Create a new SpriteBatch, which can be used to draw textures.
        //    this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);

        //    Loader load = new Loader();
        //    string msg = string.Empty;

        //    load.LoadAll(ref msg, new List<Assembly>
        //    {
        //        Assembly.GetAssembly(typeof(World)),
        //        Assembly.GetAssembly(typeof(Game1)),
        //        Assembly.GetAssembly(typeof(PointTeacher))
        //    });

        //    WindowConfig winConfig = new WindowConfig();
        //    winConfig.ConfigureMainWindow(this);

        //    // TODO: use this.Content to load your game content here
        //}

        ///// <summary>
        ///// UnloadContent will be called once per game and is the place to unload
        ///// game-specific content.
        ///// </summary>
        //protected override void UnloadContent()
        //{
        //    // TODO: Unload any non ContentManager content here
        //}

        ///// <summary>
        ///// Allows the game to run logic such as updating the world,
        ///// checking for collisions, gathering input, and playing audio.
        ///// </summary>
        ///// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Update(GameTime gameTime)
        //{
        //    if (this.IsActive)
        //    {
        //        BoundHandler.UpdateMouseInput(gameTime);
        //        KeyboardHandler.UpdateKeyboardInput(gameTime);
        //    }

        //    base.Update(gameTime);
        //}

        // graphics and spritebatch
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        /// Game constructor.
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Game1.AssetManager = this.Content;
        }

        /// Allows the game to perform any initialization it needs to before starting to run.
        /// here we create and init the UI manager.
        protected override void Initialize()
        {
            // GeonBit.UI: Init the UI manager using the "hd" built-in theme
            UserInterface.Initialize(Content, BuiltinThemes.hd);

            // GeonBit.UI: tbd create your GUI layouts here..

            // call base initialize func
            base.Initialize();
        }

        /// LoadContent will be called once per game and is the place to load.
        /// here we init the spriteBatch (this is code you probably already have).
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

            // tbd add your own update() stuff here..

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