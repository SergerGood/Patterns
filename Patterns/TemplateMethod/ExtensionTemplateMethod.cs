using System;
using System.Text;


namespace Patterns.TemplateMethod
{
    public static class ExtensionTemplateMethod
    {
        public static string GetText(this LogEntryBase logEntry)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("[{0}] ", logEntry.EntryDateTime)
                .AppendLine(logEntry.Message)
                .AppendLine(logEntry.AdditionalInformation);

            return sb.ToString();
        }
    }
}
