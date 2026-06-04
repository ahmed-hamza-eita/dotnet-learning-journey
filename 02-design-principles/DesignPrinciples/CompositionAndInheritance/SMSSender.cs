public class SMSSender : INotificationSender
{
    public void Send(string msg)
    {
        Console.WriteLine($"Sending SMS: {msg}");
    }
}