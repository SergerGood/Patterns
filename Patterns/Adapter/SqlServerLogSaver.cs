using System;


namespace Patterns.Adapter
{
    public class SqlServerLogSaver
    {
        public void Save(DateTime dateTime, object severity, string message)
        {
            
        }

        public void SaveException(DateTime dateTime, string message, Exception exception)
        {

        }
    }
}