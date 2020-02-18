using MailKit.Net.Smtp;
using MimeKit;

namespace BirthdayGreetings.Tests
{
    public class MessageService : IMessageService
    {
        private string smtpHost;
        private int smtpPort;

        public MessageService(string smtpHost,int smtpPort)
        {
            this.smtpPort = smtpPort;
            this.smtpHost = smtpHost;
        }

        public void SendMessage(string senderHereCom, string subject, string body, string recipient)
        {
             var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderHereCom));
                message.To.Add(new MailboxAddress(recipient));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };
                // Send the message
                SendMessage(smtpHost, smtpPort, message);
           
        }
        
        // made protected for testing :-( 
        // this was originally needed in java  - check if is needed here as well.
        protected void SendMessage(string smtpHost, int smtpPort, MimeMessage message)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(smtpHost, smtpPort, false);
                // smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                // // Note: since we don't have an OAuth2 token, disable 	
                // // the XOAUTH2 authentication mechanism.     
                // smtpClient.Authenticate("info@MyWebsiteDomainName.com", "myIDPassword");
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
            }
        }
    }
}