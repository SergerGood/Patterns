using System;
using System.Threading.Tasks;


namespace Patterns.Decorator
{
    public class ThrottlingLogSaverDecorator : LogSaverDecorator
    {
        public ThrottlingLogSaverDecorator(ILogSaver decoratee)
            : base(decoratee)
        {
        }


        public override async Task SaveLogEntry(string applicationId, LogEntry logEntry)
        {
            if (!QuotaReached(applicationId))
            {
                IncrementUsedQuota();

                await decoratee.SaveLogEntry(applicationId, logEntry);
                return;
            }

            //throw new QuotaReachedException();
        }


        private bool QuotaReached(string applicationId)
        {
            return true;
        }


        private void IncrementUsedQuota()
        {
        }
    }
}
