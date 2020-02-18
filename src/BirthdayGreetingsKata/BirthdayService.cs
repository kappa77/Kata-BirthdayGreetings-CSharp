// using System.Net.Mail;

using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;

namespace BirthdayGreetings
{
    public class BirthdayService
    {
        private readonly IGreetingMessageService _greetingMessageService;
        private readonly IEmployeeRepository _employeeRepository;

        public BirthdayService(IGreetingMessageService greetingMessageService,IEmployeeRepository  employeeRepository)
        {
            _greetingMessageService = greetingMessageService;
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
                    _greetingMessageService.SendMessage( greetingMessage );
                }
            }

        }

    }
}