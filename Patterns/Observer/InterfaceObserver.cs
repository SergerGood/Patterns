using System;


namespace Patterns.Observer
{
    public class InterfaceObserver
    {
        public interface ILogFileReaderObserver
        {
            void NewLogEntry(string logEntry);
            void FileWasRolled(string oldLogFile, string newLogFile);
        }


        public class LogFileReader
        {
            private readonly string logFileName;
            private readonly ILogFileReaderObserver observer;


            public LogFileReader(string logFileName,
                ILogFileReaderObserver observer)
            {
                this.logFileName = logFileName;
                this.observer = observer;
            }


            private void DetectThatNewFileWasCreated()
            {
                if (NewLogFileWasCreated())
                    observer.FileWasRolled(logFileName, GetNewLogFileName());
            }


            private string GetNewLogFileName()
            {
                return string.Empty;
            }


            private bool NewLogFileWasCreated()
            {
                return true;
            }
        }
    }
}
