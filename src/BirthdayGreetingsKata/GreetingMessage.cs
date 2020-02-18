namespace BirthdayGreetings
{
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