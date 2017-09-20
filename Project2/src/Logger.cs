using System;

namespace service
{
    enum LogLevel
    {
        Emergency,
        Alert,
        Critical,
        Error,
        Warning,
        Notice,
        Info,
        Debug
    }
    static class Logger
    {
        //Writes to Standard Output
        public static void Log(string message, LogLevel level)
        {
            string strLevel = $"<{(int)level}>";
            Console.WriteLine($"{strLevel}{message}");
        }

        //Writes to Standard Error
        public static void LogError(string message, LogLevel level)
        {
            string strLevel = $"<{(int)level}>";
            Console.Error.WriteLine($"{strLevel}{message}");
        }
    }
}