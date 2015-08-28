using System;


namespace Patterns.Visitor
{
    public class InterfaceVisitor
    {
        public interface ILogEntryVisitor
        {
            void Visit(ExceptionLogEntry exceptionLogEntry);
            void Visit(LogEntry logEntry);
        }


        public abstract class LogEntry
        {
            public abstract void Accept(ILogEntryVisitor logEntryVisitor);
        }


        public class ExceptionLogEntry : LogEntry
        {
            public override void Accept(ILogEntryVisitor logEntryVisitor)
            {
                logEntryVisitor.Visit(this);
            }
        }
    }
}
