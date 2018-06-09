using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Input.Specialized_Handlers;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 4;
        }

        public void InitialStartup(ref int progress)
        {
            KeyboardHandler.Initialize();
            progress++;
            InputHistory.Initialize();
            progress++;
            InputHandlers.Initialize();
            progress++;
            BoundHandler.Initialize();
            progress++;
        }
    }
}