namespace HomeWork11
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public LogLevel Level { get; set; }
        public string? Message { get; set; }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
