using System;
using System.Collections.Generic;


namespace Patterns.FactoryMethod
{
    public class StaticFactoryMethod
    {
        private static class ImporterFactory
        {
            private static readonly Dictionary<bool, Func<LogEntry>> map = new Dictionary<bool, Func<LogEntry>>();


            static ImporterFactory()
            {
                map[true] = () => new LogEntry(string.Empty);
                map[false] = () => new ExceptionLogEntry(string.Empty);
            }


            public static LogEntry Create(bool tag)
            {
                var entry = GetLogEntry(tag);

                return entry();
            }


            private static Func<LogEntry> GetLogEntry(bool tag)
            {
                Func<LogEntry> logEntry;
                map.TryGetValue(tag, out logEntry);

                return logEntry;
            }
        }
    }
}
