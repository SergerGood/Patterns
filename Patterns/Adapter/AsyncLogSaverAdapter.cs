using System;
using System.Threading.Tasks;


namespace Patterns.Adapter
{
    public class AsyncLogSaverAdapter : IAsyncLogSaver
    {
        private readonly ILogSaver logSaver;


        public AsyncLogSaverAdapter(ILogSaver logSaver)
        {
            this.logSaver = logSaver;
        }


        public Task SaveAsync(LogEntry logEntry)
        {
            return Task.Run(() => logSaver.Save(logEntry));
        }
    }
}
