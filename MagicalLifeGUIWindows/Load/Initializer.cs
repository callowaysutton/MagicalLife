using MagicalLifeAPI.Universal;

namespace MagicalLifeGUIWindows.Load
{
    public class Initializer : IGameLoader
    {
        public int GetTotalOperations()
        {
            return 0;
        }

        public void InitialStartup(ref int progress)
        {
            //InputHistory.Initialize();
            //progress++;
            //InputHandlers.Initialize();
            //progress++;
        }
    }
}