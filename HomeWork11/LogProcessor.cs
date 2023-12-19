using System.Reflection.Metadata.Ecma335;
using static HomeWork11.LogEntry;

namespace HomeWork11
{
    public class LogProcessor : EventArgs
    {
        public delegate void ShowMessage(string message);
        public event ShowMessage ErrorOccurred;
        private readonly List<LogEntry> logs;
        public LogProcessor()
        {
            logs = new List<LogEntry>();
        }

        public void AddLog(LogEntry newLog)
        {
            if (newLog is null)
            {
                throw new ArgumentNullException(nameof(newLog));
            }
            else
            {
                logs.Add(newLog);
            }
        }

        public void FilterByLevel(LogLevel level)
        {
            var number = logs.Where(l => l.Level == level);
            foreach (var log in number)
            {
                if (level == LogLevel.Info)
                {
                    Console.WriteLine($"Группа 1 (Информация): {log.Timestamp}, {log.Level}, {log.Message}");
                }
                else if (level == LogLevel.Warning)
                {
                    Console.WriteLine($"Группа 2 (Предупреждения): {log.Timestamp}, {log.Level}, {log.Message}");
                }
                else
                    Console.WriteLine($"Группа 3 (Ошибки): {log.Timestamp}, {log.Level}, {log.Message}");
            }
        }

        public void CountErrors()
        {
            var number = logs.Where(l => l.Level == LogLevel.Error);
            int count = 0;
            foreach (var log in number)
            {
                count++;
            }
            Console.WriteLine($"Количество ошибок в логах: {count}");
        }

        public void FindRecentLogs(DateTime since)
        {
            var number = logs.Where(t => t.Timestamp > since);
            Console.WriteLine($"Логи после {since}:");
            foreach (var log in number)
            {
                Console.WriteLine($"{log.Timestamp}, {log.Level}, {log.Message}");
            }
        }

        public void GroupByLevel()
        {
            var grouped = logs.GroupBy(l => l.Level == LogLevel.Error && l.Level == LogLevel.Warning && l.Level == LogLevel.Info);
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            foreach (var group in grouped)
            {
                foreach (var log in group)
                {
                    if (log.Level == LogLevel.Error)
                    {
                        count1++;
                    }
                    else if (log.Level == LogLevel.Warning)
                    {
                        count2++;
                    }
                    else
                        count3++;
                }
            }
            Console.WriteLine($"Группа 1 (Информация) содержит {count3} логов\n" +
                  $"Группа 2 (Предупреждения) содержит {count2} логов\n" +
                  $"Группа 3 (Ошибки) содержит {count1} логов");
        }

        public void FindTopLogs(string keyword)
        {
            int count = 0;
            var logsFound = logs.Where(l => l.Level.ToString().ToLower() == keyword.ToLower()).OrderByDescending(l => l.Timestamp);

            foreach (var log in logsFound)
            {
                Console.WriteLine($"{log.Timestamp}, {log.Level}, {log.Message}");
                count++;
            }
            Console.WriteLine($"Количество логов {keyword} составляет: {count}");

        }

        public void FindError()
        {
            foreach (var log in logs)
            {
                if ((log.Level == LogLevel.Error))
                {
                    ErrorOccurred?.Invoke($"Обнаружена ошибка: {log.Timestamp}, {log.Level}, {log.Message}");
                }
            }
        }
    }
}
