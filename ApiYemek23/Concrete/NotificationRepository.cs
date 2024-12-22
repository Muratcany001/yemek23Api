using ApiYemek23.Abstract;

namespace ApiYemek23.Concrete
{
    public class NotificationRepository: INotificationService
    {
        private static NotificationRepository _instance;
        public static NotificationRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NotificationRepository();
            }
            return _instance;
        }
        public void ShowRegisterationNotification(string User_Name)
        {
            Console.WriteLine($"{User_Name} Adlı kullanıcı baiarıyla kaydedildi");
        }
        public void ShowLoginNotification(string User_Name)
        {
            Console.WriteLine($"{User_Name} Adlı kullanıcı başarıyla giriş yaptı");
        }

    }
}
