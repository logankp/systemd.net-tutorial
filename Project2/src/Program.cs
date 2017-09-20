using System;
using System.Threading;
using System.Runtime.Loader;
using System.Linq;
using System.Collections.Generic;

namespace service
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyLoadContext.Default.Unloading += SigTermEventHandler;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelHandler);
            Logger.Log("This is an emergency!", LogLevel.Emergency);
            while (true)
            {
                Console.WriteLine("This is a normal message");
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
            System.Console.WriteLine("Unloading...");
        }

        private static void CancelHandler(object sender, ConsoleCancelEventArgs e)
        {
            System.Console.WriteLine("Exiting...");
        }
    }
}
