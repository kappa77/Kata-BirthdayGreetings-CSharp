using MailKit.Net.Smtp;
using MimeKit;

namespace BirthdayGreetings.Tests
{
    public class GreetingMessageService : IGreetingMessageService
    {
        private string smtpHost;
        private int smtpPort;
        private readonly string _sender;

        public GreetingMessageService(string smtpHost,int smtpPort, string sender)
        {
            this.smtpPort = smtpPort;
            _sender = sender;
            this.smtpHost = smtpHost;
        }

        public void SendMessage(  GreetingMessage greetingMessage)
        {
             var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_sender));
                message.To.Add(new MailboxAddress(greetingMessage.Recipient));
                message.Subject = greetingMessage.Subject;
                message.Body = new TextPart("plain")
                {
                    Text = greetingMessage.Body
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