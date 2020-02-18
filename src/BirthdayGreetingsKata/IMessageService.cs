namespace BirthdayGreetings
{
    public interface IMessageService
    {
        void SendMessage(string senderHereCom, string subject, string body, string recipient);
    }
}