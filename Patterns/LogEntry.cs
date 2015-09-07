using System;


namespace Patterns
{
    public class LogEntry
    {
        private string line;


        public LogEntry()
            : this(string.Empty)
        {
        }


        public LogEntry(string line)
        {
            this.line = line;
        }


        public static LogEntry Parse(string line)
        {
            return new LogEntry(line);
        }

        public DateTime EntryDateTime { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
