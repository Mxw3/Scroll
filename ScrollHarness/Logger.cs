using Microsoft.Extensions.Logging;
using Scroll;

namespace ScrollHarness
{
    internal class Logger : ILogger<WindowsBackgroundService>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        IList<object> logs = new List<object>();
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            logs.Add(new Log<TState>
            {
                LogLevel = logLevel,
                EventId = eventId,
                State = state,
                Exception = exception,
                Formatter = formatter,
            });
        }
    }
}
