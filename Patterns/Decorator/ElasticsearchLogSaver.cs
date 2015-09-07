using System;
using System.Threading.Tasks;


namespace Patterns.Decorator
{
    public sealed class ElasticsearchLogSaver : ILogSaver
    {
        public Task SaveLogEntry(string applicationId, LogEntry logEntry)
        {
            return Task.FromResult<object>(null);
        }
    }
}
