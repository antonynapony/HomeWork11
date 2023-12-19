using HomeWork11;
using static HomeWork11.LogEntry;
class Program
{
    public static void Main(string[] args)
    {
        LogProcessor logs = new LogProcessor();
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Error log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Info log", Level = LogEntry.LogLevel.Info });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Warning log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 17), Message = "Info log", Level = LogEntry.LogLevel.Info });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Warning log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 19), Message = "Error log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 18), Message = "Info log", Level = LogEntry.LogLevel.Info });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 12), Message = "Warning log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 12), Message = "Error log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 20), Message = "Error log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 20), Message = "Warning log", Level = LogEntry.LogLevel.Warning });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 19), Message = "Error log", Level = LogEntry.LogLevel.Error });
        logs.AddLog(new LogEntry() { Timestamp = new DateTime(2023, 12, 17), Message = "Error log", Level = LogEntry.LogLevel.Error });


        logs.FilterByLevel(LogLevel.Info);
        logs.FilterByLevel(LogLevel.Warning);
        logs.FilterByLevel(LogLevel.Error);
        Console.ReadKey();
        logs.CountErrors();
        Console.ReadKey();
        logs.FindRecentLogs(new DateTime(2023, 12, 16));
        Console.ReadKey();
        logs.GroupByLevel();
        Console.ReadKey();
        logs.FindTopLogs("info");
        Console.ReadKey();
        logs.ErrorOccurred += ErrorFound;
        logs.FindError();
    }

    public static void ErrorFound(string message)
    {
        Console.WriteLine(message);
    }
}