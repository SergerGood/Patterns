using System;
using System.Collections.Generic;
using System.Data.Common;


namespace Patterns.AbstractFactory
{
    public class LogSaver
    {
        private readonly DbProviderFactory factory;


        public LogSaver(DbProviderFactory factory)
        {
            this.factory = factory;
        }


        public void Save(IEnumerable<LogEntry> logEntries)
        {
            using (var connection = factory.CreateConnection())
            {
                SetConnectionString(connection);
                using (var command = factory.CreateCommand())
                {
                    SetCommandArguments(logEntries);
                    command.ExecuteNonQuery();
                }
            }
        }


        private void SetConnectionString(DbConnection connection)
        {
        }


        private void SetCommandArguments(IEnumerable<LogEntry> logEntry)
        {
        }
    }
}
