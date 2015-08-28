using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace Patterns.Iterator
{
    public class LogFileSource : IEnumerable<LogEntry>
    {
        private readonly string logFileName;


        public LogFileSource(string logFileName)
        {
            this.logFileName = logFileName;
        }


        public IEnumerator<LogEntry> GetEnumerator()
        {
            foreach (var line in File.ReadAllLines(logFileName))
            {
                yield return LogEntry.Parse(line);
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
