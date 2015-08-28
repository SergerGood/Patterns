using System;


namespace Patterns
{
    public abstract class LogEntryBase
    {
        public DateTime EntryDateTime { get; internal set; }
        public string Message { get; internal set; }
        public string AdditionalInformation { get; internal set; }
    }
}
