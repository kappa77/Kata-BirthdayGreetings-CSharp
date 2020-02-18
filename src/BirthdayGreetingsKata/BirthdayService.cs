// using System.Net.Mail;
using System.IO;
using MailKit.Net.Smtp;
using MimeKit;

namespace BirthdayGreetings
{
    public class BirthdayService
    {
        private readonly IMessageService _messageService;

        public BirthdayService(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void SendGreetings(string fileName, XDate xDate )
        {
            if (System.IO.File.Exists(fileName))
            {
                var objStream = new FileStream(fileName, FileMode.Open);
                var objReader = new StreamReader(objStream);
                do
                {
                    var textLine = objReader.ReadLine();
                    if (!string.IsNullOrEmpty(textLine) && !textLine.Contains("last_name"))
                    {
                        var employeeData = textLine.Split(new char[] { ',' });
                        var employee = new Employee
                        {
                            FirstName = employeeData[1],
                            LastName = employeeData[0],
                            BirthDate = new XDate(employeeData[2]),
                            Email = employeeData[3]
                        };
                        if (employee.IsBirthday(xDate))
                        {
                            var recipient = employee.Email;
                            var body = string.Format("Happy Birthday, dear {0}!", employee.FirstName);
                            var subject = "Happy Birthday!";
                            _messageService.SendMessage("sender@here.com", subject, body, recipient);
                            
                        }
                    }
                } while (objReader.Peek() != -1);
            }

        }

        

    }
}