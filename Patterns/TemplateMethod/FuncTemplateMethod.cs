using System;
using System.Collections.Generic;
using System.ServiceModel;


namespace Patterns.TemplateMethod
{
    public class FuncTemplateMethod
    {
        private interface ILogSaver
        {
            void UploadLogEntries(IEnumerable<LogEntry> logEntries);
            void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions);
        }


        private class LogSaverProxy : ILogSaver
        {
            public void UploadLogEntries(IEnumerable<LogEntry> logEntries)
            {
                UseProxyClient(c => c.UploadLogEntries(logEntries));
            }


            public void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions)
            {
                UseProxyClient(c => c.UploadExceptions(exceptions));
            }


            private void UseProxyClient(Action<ILogSaver> accessor)
            {
                var client = new LogSaverClient();
                try
                {
                    accessor(client.LogSaver);
                    client.Close();
                }
                catch (CommunicationException e)
                {
                    client.Abort();
                    //throw new OperationFailedException(e);
                }
            }


            private class LogSaverClient : ClientBase<ILogSaver>
            {
                public ILogSaver LogSaver => Channel;
            }
        }
    }
}
