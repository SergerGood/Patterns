using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Patterns.Decorator
{
    public class TraceLogSaverDecorator : LogSaverDecorator
    {
        public TraceLogSaverDecorator(ILogSaver decoratee) : base(decoratee)
        {
        }


        public override async Task SaveLogEntry(string applicationId, LogEntry logEntry)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await decoratee.SaveLogEntry(applicationId, logEntry);
            }
            finally
            {
                Trace.TraceInformation("Операция сохранения завершена за {0}мс", sw.ElapsedMilliseconds);
            }
        }
    }
}
