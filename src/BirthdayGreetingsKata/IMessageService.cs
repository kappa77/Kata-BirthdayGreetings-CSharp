namespace BirthdayGreetings
{
    public interface IMessageService
    {
        void SendMessage(string senderHereCom, BirthdayService.GreetingMessage greetingMessage);
    }
}