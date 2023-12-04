using Common.Helpers;
using Common.LoggerManager;
using System;
using System.Diagnostics;

namespace LoggerManager.ConsoleLogger
{
    public static class DisplayLogger
    {
        private const int filenameSpaceFill = 20;
        private const char filenameSpaceFillChar = ' ';

        public static void WriteLine(string message)
        {
            Debug.WriteLine($"{Utils.FormatStringAsRequired(message, filenameSpaceFill, filenameSpaceFillChar)}");
            Console.WriteLine($"{Utils.FormatStringAsRequired(message, filenameSpaceFill, filenameSpaceFillChar)}");
            Logger.info($"{Utils.FormatStringAsRequired(message, filenameSpaceFill, filenameSpaceFillChar)}");
        }
    }
}
