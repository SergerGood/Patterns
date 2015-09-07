using System.Net.Mail;


namespace Patterns.Builder
{
    public class FinalMailMessageBuilder
    {
        private readonly MailMessage mailMessage;


        internal FinalMailMessageBuilder(MailMessage mailMessage)
        {
            this.mailMessage = mailMessage;
        }


        public MailMessage Build()
        {
            return mailMessage;
        }
    }
}