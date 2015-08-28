using System;
using System.Collections.Generic;
using System.IO;


namespace Patterns.FactoryMethod
{
    public abstract class LogReaderBase
    {
        public IEnumerable<LogEntry> Read()
        {
            using (var stream = OpenLogSource())
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return LogEntryParser.Parse(line);
                    }
                }
            }
        }


        protected abstract Stream OpenLogSource();


        private static class LogEntryParser
        {
            public static LogEntry Parse(string data)
            {
                return new LogEntry(data);
            }
        }
    }
}
