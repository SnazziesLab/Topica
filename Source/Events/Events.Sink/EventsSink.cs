using Serilog.Core;
using Serilog.Events;

namespace Events.Sink
{
    public class EventsSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;

        public EventsSink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public void Emit(LogEvent logEvent)
        {
            var message = logEvent.RenderMessage(_formatProvider);
            Console.WriteLine(DateTimeOffset.Now.ToString() + " " + message);
        }
    }
}
