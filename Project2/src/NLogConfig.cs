using System;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace service
{
    static class NLogConfig
    {
        public static void Configure()
        {
            LayoutRenderer.Register<SyslogLevelLayoutRenderer>("syslog-level");
            var config = new LoggingConfiguration();
            var consoleTarget = new ConsoleTarget();
            config.AddTarget("console", consoleTarget);
            consoleTarget.Layout = @"${syslog-level}${message}";

            var rule = new LoggingRule("*", NLog.LogLevel.Info, consoleTarget);
            config.LoggingRules.Add(rule);
            LogManager.Configuration = config;
        }
    }
}