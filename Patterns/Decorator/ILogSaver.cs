using System.Threading.Tasks;


namespace Patterns.Decorator
{
    public interface ILogSaver
    {
        Task SaveLogEntry(string applicationId, LogEntry logEntry);
    }
}