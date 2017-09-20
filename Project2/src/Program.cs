using System;
using System.Threading;
using System.Runtime.Loader;
using System.Linq;
using System.Collections.Generic;
using NLog.LayoutRenderers;
using NLog;

namespace service
{
    class Program
    {
        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            NLogConfig.Configure();
            _logger.Info("Service starting");
            AssemblyLoadContext.Default.Unloading += SigTermEventHandler;
            Console.CancelKeyPress += CancelHandler;
            Logger.Log("This is an emergency!", LogLevel.Emergency); //only do this once

            while (true)
            {
                foreach(LogLevel level in Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>()
                .Where(i => i != LogLevel.Emergency)) //skip emergency so we don't get spammed by console notifications
                {
                    var strLevel = Enum.GetName(typeof(LogLevel), level);
                    Logger.Log($"LogLevel: {strLevel}", level);
                }
                Logger.LogError("This will print to StdErr", LogLevel.Error);
                Thread.Sleep(5000);
            }
        }

        private static void SigTermEventHandler(AssemblyLoadContext obj)
        {
            _logger.Warn("Unloading");
        }

        private static void CancelHandler(object sender, ConsoleCancelEventArgs e)
        {
            _logger.Info("Exiting");
        }
    }
}
