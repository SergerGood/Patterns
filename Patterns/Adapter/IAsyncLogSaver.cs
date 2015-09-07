using System;
using System.Threading.Tasks;


namespace Patterns.Adapter
{
    public interface IAsyncLogSaver
    {
        Task SaveAsync(LogEntry logEntry);
    }
}
