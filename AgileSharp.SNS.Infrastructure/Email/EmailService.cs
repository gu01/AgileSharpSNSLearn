using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using AgileSharp.SNS.Infrastructure.Config;
using StructureMap;


namespace AgileSharp.SNS.Infrastructure.Email
{
    public class EmailService : IEmail
    {
        private IConfiguration configuration;

        public EmailService()
        {
            configuration = ObjectFactory.GetInstance<IConfiguration>();
        }

        public void SendEmail(string to, string subject, string message)
        {
            MailMessage mm = new MailMessage(configuration.EmailFromAddress, to);
            mm.Subject = subject;
            mm.Body = message;
            Send(mm);
        }

        public void SendEmail(string to, string cc, string bcc, string subject, string message)
        {
            MailMessage mm = new MailMessage(configuration.EmailFromAddress, to);
            mm.CC.Add(cc);
            mm.Bcc.Add(bcc);
            mm.Subject = subject;
            mm.Body = message;
            mm.IsBodyHtml = true;
            Send(mm);
        }

        public void SendEmail(string[] to, string[] cc, string[] bcc, string subject, string message)
        {
            MailMessage mm = new MailMessage();
            foreach (var t in to)
            {
                mm.To.Add(t);
            }

            foreach (var c in cc)
            {
                mm.CC.Add(c);
            }

            foreach (var b in bcc)
            {
                mm.Bcc.Add(b);
            }

            mm.From = new MailAddress(configuration.EmailFromAddress);
            mm.Subject = subject;
            mm.Body = message;
            mm.IsBodyHtml = true;
            Send(mm);
        }

        public void SendIndiviualEmailPerRecipient(string[] to, string subject, string message)
        {
            foreach (var t in to)
            {
                MailMessage mm = new MailMessage(configuration.EmailFromAddress, t);
                mm.Subject = subject;
                mm.Body = message;
                mm.IsBodyHtml = true;
                Send(mm);
            }
        }

        private void Send(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
}
