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
            Console.WriteLine(GetLogMessage(message, level));
        }

        //Writes to Standard Error
        public static void LogError(string message, LogLevel level)
        {
            Console.Error.WriteLine(GetLogMessage(message, level));
        }

        private static string GetLogMessage(string message, LogLevel level)
        {
            string strLevel = $"<{(int)level}>";
            return $"{strLevel}{message}";
        }
    }
}