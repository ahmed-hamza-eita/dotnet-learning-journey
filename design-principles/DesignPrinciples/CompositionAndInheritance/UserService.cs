public class UserService
{

    public readonly INotificationSender notificationSender;

    public UserService(INotificationSender notificationSender)
    {
        this.notificationSender = notificationSender;
    }

    public void NoftifyUser(string msg)
    {
        
        notificationSender.Send(msg);
    }

}