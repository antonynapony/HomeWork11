using HomeWork11;
using static HomeWork11.LogEntry;
class Program
{
    public static void Main(string[] args)
    {
        LogProcessor logs = new LogProcessor();
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Authentication log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Server log", Level = LogEntry.LogLevel.Info });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Server log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 17), Message = "Authorization log", Level = LogEntry.LogLevel.Info });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "System log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 19), Message = "Server log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "System log", Level = LogEntry.LogLevel.Info });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 12), Message = "Authentication log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 12), Message = "System log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 20), Message = "Authentication log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 20), Message = "System log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 19), Message = "Authorization log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 17), Message = "Authorization log", Level = LogEntry.LogLevel.Error });

        logs.FilterByLevel(LogLevel.Info);
        logs.FilterByLevel(LogLevel.Warning);
        logs.FilterByLevel(LogLevel.Error);
        Console.ReadKey();
        Console.WriteLine($"Количество ошибок в логах: {logs.CountErrors()}");
        Console.ReadKey();
        logs.FindRecentLogs(new DateTime(2023, 12, 16));
        Console.ReadKey();
        logs.GroupByLevel();
        Console.ReadKey();
        logs.FindTopLogs("system", 7);
        Console.ReadKey();
        logs.ErrorOccurred += ErrorFound;
        logs.CheckErrors();
    }

    public static void ErrorFound(string message)
    {
        Console.WriteLine(message);
    }
}