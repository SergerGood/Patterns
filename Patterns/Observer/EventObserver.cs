using System;


namespace Patterns.Observer
{
    public class EventObserver
    {
        public class LogEntryEventsArgs : EventArgs
        {
            public LogEntry LogEntry { get; internal set; }
        }


        public class LogFileReader
        {
            private readonly string logFileName;


            public LogFileReader(string logFileName)
            {
                this.logFileName = logFileName;
            }


            public event EventHandler<LogEntryEventsArgs> OnNewLogEntry;


            private void CheckFile()
            {
                var logEntries = new[]
                {
                    new LogEntry(string.Empty),
                    new ExceptionLogEntry(string.Empty)
                };

                foreach (var logEntry in logEntries)
                {
                    RaiseNewLogentry(logEntry);
                }
            }


            private void RaiseNewLogentry(LogEntry logEntry)
            {
                var handler = OnNewLogEntry;

                handler?.Invoke(this, new LogEntryEventsArgs { LogEntry = logEntry });
            }
        }
    }
}
