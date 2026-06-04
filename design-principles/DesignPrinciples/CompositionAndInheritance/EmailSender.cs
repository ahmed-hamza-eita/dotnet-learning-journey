public class EmailSender : INotificationSender
{
    public void Send(string msg)
    {
        Console.WriteLine($"Sending Email: {msg}");
    }
}