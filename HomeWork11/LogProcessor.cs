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
            var result = from l in logs where l.Level == level select l;
            foreach (var log in result)
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

        public int CountErrors()
        {
            int count = 0;
            var result = from l in logs where l.Level == LogLevel.Error select l;
            foreach (var log in result)
            {
                count++;
            }
            return count;

        }

        public void FindRecentLogs(DateTime since)
        {
            var result = from l in logs where l.Timestamp > since select l;
            Console.WriteLine($"Логи после {since}:");
            var finalResult = from l in result orderby l.Timestamp ascending select l;
            foreach (var log in finalResult)
            {
                Console.WriteLine($"{log.Timestamp}, {log.Level}, {log.Message}");
            }
        }

        public void GroupByLevel()
        {
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            var grouped = logs.GroupBy(l => l.Level);

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

        public void FindTopLogs(string keyword, int count)
        {
            var logsFound = from l in logs
                            where l.Message.ToString().ToLower().Contains(keyword.ToLower())
                            select l;
            var result = from l in logsFound.Take(count)
                         orderby l.Timestamp ascending
                         select l;
            foreach (var log in result)
            {
                Console.WriteLine($"{log.Timestamp}, {log.Level}, {log.Message}");
            }
        }

        public void CheckErrors()
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
