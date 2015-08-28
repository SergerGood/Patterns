using System;


namespace Patterns
{
    public class LogEntry
    {
        private string line;


        public LogEntry(string line)
        {
            this.line = line;
        }


        public static LogEntry Parse(string line)
        {
            return new LogEntry(line);
        }
    }
}
