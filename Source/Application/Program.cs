using Application.Config;
using ComportMapper.ComPortFinder;
using System;

namespace COMPORT_MAPPER
{
    class Program
    {
        private static AppConfig configuration;

        static void Main(string[] args)
        {
            configuration = SetupEnvironment.SetEnvironment();

            // search for all available Ports
            if (ComportSearcher.FindAllComports() > 0)
            {
                ComportSearcher.ListAllDevices();
            }

            // Wait for key press to exit
            SetupEnvironment.WaitForExitKeyPress();
        }
    }
}
