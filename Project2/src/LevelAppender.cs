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
                builder.Append($"<{(int)LogLevel.Critical}>");
            else if (logEvent.Level == NLog.LogLevel.Error)
                builder.Append($"<{(int)LogLevel.Error}>");
            else if (logEvent.Level == NLog.LogLevel.Warn)
                builder.Append($"<{(int)LogLevel.Warning}>");
            else if (logEvent.Level == NLog.LogLevel.Info)
                builder.Append($"<{(int)LogLevel.Info}>");
            else if (logEvent.Level == NLog.LogLevel.Debug || logEvent.Level == NLog.LogLevel.Trace)
                builder.Append($"<{(int)LogLevel.Debug}>");
        }
    }
}