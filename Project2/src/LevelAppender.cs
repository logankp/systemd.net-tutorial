using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace service
{
    [LayoutRenderer("syslog-level")]
    public class SyslogLevelLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if (logEvent.Level == NLog.LogLevel.Fatal)
                builder.Append(GetLevelString(LogLevel.Critical));
            else if (logEvent.Level == NLog.LogLevel.Error)
                builder.Append(GetLevelString(LogLevel.Error));
            else if (logEvent.Level == NLog.LogLevel.Warn)
                builder.Append(GetLevelString(LogLevel.Warning));
            else if (logEvent.Level == NLog.LogLevel.Info)
                builder.Append(GetLevelString(LogLevel.Info));
            else if (logEvent.Level == NLog.LogLevel.Debug || logEvent.Level == NLog.LogLevel.Trace)
                builder.Append(GetLevelString(LogLevel.Debug));
        }

        private string GetLevelString(LogLevel level)
        {
            return $"<{(int)level}>";
        }
    }
}