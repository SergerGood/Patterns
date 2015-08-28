using System;
using System.Collections.Generic;


namespace Patterns.Strategy
{
    public sealed class FuncStrategy
    {
        private Func<List<LogEntry>> logImporterFunc;


        public FuncStrategy(Func<List<LogEntry>> logImporterFunc)
        {
            this.logImporterFunc = logImporterFunc;
        }


        public void ProcessLog()
        {
            foreach (var logEntry in logImporterFunc.Invoke())
            {
                
            }
        }
    }
}
