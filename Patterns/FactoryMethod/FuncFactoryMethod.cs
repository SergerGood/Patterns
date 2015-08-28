using System;
using System.Collections.Generic;
using System.IO;


namespace Patterns.FactoryMethod
{
    public class FuncFactoryMethod
    {
        public class LogReader
        {
            private readonly Func<Stream> streamFactory;


            private LogReader(Func<Stream> streamFactory)
            {
                this.streamFactory = streamFactory;
            }


            public static LogReader FromFile(string fileName)
            {
                Func<Stream> factory = () => new FileStream(fileName, FileMode.Open);
                return new LogReader(factory);
            }


            public static LogReader FromStream(Stream stream)
            {
                Func<Stream> factory = () => stream;
                return new LogReader(factory);
            }


            public IEnumerable<LogEntry> Read()
            {
                using (var stream = OpenLogSource())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line = null;
                        while ((line = reader.ReadLine()) != null)
                        {
                            yield return LogEntry.Parse(line);
                        }
                    }
                }
            }


            private Stream OpenLogSource()
            {
                return streamFactory();
            }
        }
    }
}
