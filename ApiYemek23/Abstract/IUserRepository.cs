using ApiYemek23.Entities.AppEntities;

namespace ApiYemek23.Abstract
{
    public interface IUserRepository
    {
        User CreateUser (User user);
        List<User> GetUser ();
        User GetUserByMail (string mail);
        Task<User> GetUserById (int id);
        User UpdateUser (User user);
        Task<User> AddFavoriteAsync(int User_Id, int Restaurant_Id);

        Task<List<int>> GetFavoritesById (int id);

        
    }
}
