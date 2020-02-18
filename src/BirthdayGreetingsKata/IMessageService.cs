namespace BirthdayGreetings
{
    public interface IMessageService
    {
        void SendMessage(  BirthdayService.GreetingMessage greetingMessage);
    }
}