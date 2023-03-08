using Microsoft.Extensions.Logging;

namespace ScrollHarness
{
    internal class Log<TState>
    {
        internal LogLevel LogLevel { get; set; }
        internal EventId EventId { get; set; }
        internal TState? State { get; set; }
        internal Exception? Exception { get; set; }
        internal Func<TState, Exception?, string>? Formatter { get; set; }
    }
}
