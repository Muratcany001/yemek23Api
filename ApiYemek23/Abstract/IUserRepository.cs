using ApiYemek23.Entities.AppEntities;

namespace ApiYemek23.Abstract
{
    public interface IUserRepository
    {
        User CreateUser (User user);
        List<User> GetUser ();
        User GetUserByMail (string mail);
        User UpdateUser (User user);
    }
}
