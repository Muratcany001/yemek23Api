namespace ApiYemek23.Abstract
{
    public interface INotificationService
    {
        void ShowRegisterationNotification(string User_Name);
        void ShowLoginNotification(string User_Name);
    }
}
