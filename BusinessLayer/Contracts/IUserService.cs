using DataAccessLayer.Models;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        User GetUserById(Guid userId);
        Guid GetUserIdByEntraId(Guid entraId);
        List<User> GetAllUsers();

        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid user);
    }
}
