using System;


namespace Patterns.Adapter
{
    public class SqlServerLogSaverAdapter : ILogSaver
    {
        private readonly SqlServerLogSaver sqlServerLogSaver = new SqlServerLogSaver();


        public void Save(LogEntry logEntry)
        {
            var simpleEntry = logEntry as SimpleLogEntry;
            if (simpleEntry != null)
            {
                sqlServerLogSaver.Save(simpleEntry.EntryDateTime,
                    simpleEntry.Severity.ToString(),
                    simpleEntry.Message);

                return;
            }
            var exceptionEntry = (ExceptionLogEntry)logEntry;

            sqlServerLogSaver.SaveException(exceptionEntry.EntryDateTime,
                exceptionEntry.Message,
                exceptionEntry.Exception);
        }
    }
}
