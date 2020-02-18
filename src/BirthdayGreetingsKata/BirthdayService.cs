// using System.Net.Mail;

using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;

namespace BirthdayGreetings
{
    public class BirthdayService
    {
        private readonly IMessageService _messageService;
        private readonly IEmployeeRepository _employeeRepository;

        public BirthdayService(IMessageService messageService,IEmployeeRepository  employeeRepository)
        {
            _messageService = messageService;
            _employeeRepository = employeeRepository;
        }
        public void SendGreetings(XDate xDate)
        {
            List<Employee> employees = _employeeRepository.GetAll();
            
            foreach (var employee in employees)
            {
                if (employee.IsBirthday(xDate))
                {
                    var greetingMessage = new GreetingMessage(employee);
                    _messageService.SendMessage("sender@here.com", greetingMessage );
                }
            }

        }

        public class GreetingMessage
        {
            public GreetingMessage(Employee employee)
            {
                Recipient = employee.Email;
                Body = string.Format("Happy Birthday, dear {0}!", employee.FirstName);
                Subject = "Happy Birthday!";
            }

            public string Subject { get; set; }

            public string Body { get; set; }

            public string Recipient { get; set; }
        }
    }
}