using System;


namespace Patterns.Visitor
{
    public class AbstractVisitor
    {
        public abstract class LogEntryVisitorBase : InterfaceVisitor.ILogEntryVisitor
        {
            public virtual void Visit(InterfaceVisitor.ExceptionLogEntry exceptionLogEntry)
            {
            }


            public virtual void Visit(InterfaceVisitor.LogEntry logEntry)
            {
            }
        }


        public class DatabaseExceptionLogEntrySaver
        {
            public void SaveLogEntry(InterfaceVisitor.LogEntry logEntry)
            {
                logEntry.Accept(new ExceptionLogEntryVisitor(this));
            }


            private class ExceptionLogEntryVisitor : LogEntryVisitorBase
            {
                private readonly DatabaseExceptionLogEntrySaver parent;


                public ExceptionLogEntryVisitor(DatabaseExceptionLogEntrySaver parent)
                {
                    this.parent = parent;
                }


                public override void Visit(InterfaceVisitor.ExceptionLogEntry exceptionLogEntry)
                {
                    //parent.SaveException(exceptionLogEntry);
                }
            }
        }
    }
}
