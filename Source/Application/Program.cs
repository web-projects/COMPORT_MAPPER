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
#if !DEBUG
            Console.WriteLine("\r\n\r\nPress <ENTER> key to exit...");

            ConsoleKeyInfo keypressed = Console.ReadKey(true);

            while (keypressed.Key != ConsoleKey.Enter)
            {
                keypressed = Console.ReadKey(true);
                System.Threading.Thread.Sleep(100);
            }
#endif

            Console.WriteLine("\r\nAPPLICATION EXITING ...");
            Console.WriteLine("");
        }
    }
}
