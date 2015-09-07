using System;


namespace Patterns.Adapter
{
    public interface ILogSaver
    {
        void Save(LogEntry logEntry);
    }
}
