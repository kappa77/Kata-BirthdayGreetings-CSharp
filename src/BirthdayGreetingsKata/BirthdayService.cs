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
                    var recipient = employee.Email;
                    var body = string.Format("Happy Birthday, dear {0}!", employee.FirstName);
                    var subject = "Happy Birthday!";
                    _messageService.SendMessage("sender@here.com", subject, body, recipient);
                }
            }

        }

    }
}