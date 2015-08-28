using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Patterns.Observer
{
    public class DelegateObserver
    {
        public class LogFileReader : IDisposable
        {
            private static readonly TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);

            private readonly Action<string> logEntrySubscriber;
            private readonly Timer timer;


            public LogFileReader(Action<string> logEntrySubscriber)
            {
                this.logEntrySubscriber = logEntrySubscriber;
                timer = new Timer(CheckFile, null, CheckFileInterval, CheckFileInterval);
            }


            public void Dispose()
            {
                timer.Dispose();
            }


            private void CheckFile(object stateInfo)
            {
                foreach (var logEntry in ReadNewLogEntries())
                {
                    logEntrySubscriber(logEntry);
                }
            }


            private IEnumerable<string> ReadNewLogEntries()
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
