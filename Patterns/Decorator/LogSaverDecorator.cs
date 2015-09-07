using System;
using System.Threading.Tasks;


namespace Patterns.Decorator
{
    public abstract class LogSaverDecorator : ILogSaver
    {
        protected readonly ILogSaver decoratee;


        protected LogSaverDecorator(ILogSaver decoratee)
        {
            this.decoratee = decoratee;
        }


        public abstract Task SaveLogEntry(string applicationId, LogEntry logEntry);
    }
}
