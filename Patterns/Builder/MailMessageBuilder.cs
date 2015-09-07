using System;
using System.Net.Mail;
using System.Text;


namespace Patterns.Builder
{
    public class MailMessageBuilder
    {
        private readonly MailMessage mailMessage;


        internal MailMessageBuilder(MailMessage mailMessage)
        {
            this.mailMessage = mailMessage;
        }


        public FinalMailMessageBuilder To(string address)
        {
            mailMessage.To(address);
            return new FinalMailMessageBuilder(mailMessage);
        }


        public MailMessageBuilder From(string address)
        {
            mailMessage.From = new MailAddress(address);
            return this;
        }


        public MailMessageBuilder Cc(string address)
        {
            mailMessage.CC.Add(address);
            return this;
        }


        public MailMessageBuilder Subject(string subject)
        {
            mailMessage.Subject = subject;
            return this;
        }


        public MailMessageBuilder Body(string body, Encoding enconding)
        {
            mailMessage.Body = body;
            mailMessage.BodyEncoding = enconding;

            return this;
        }


        public MailMessage Build()
        {
            return mailMessage;
        }
    }
}
