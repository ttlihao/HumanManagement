using HumanManagement.DataAccess.Models;

namespace HumanManagement.Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> getUsers();
        Task<User> getUser(int id);
        Task<User> getUserByUserName(string userName);
        Task<bool> createUser(User user);
        Task<bool> updateUser(User user);
        Task<bool> deleteUser(int id);
    }
}
