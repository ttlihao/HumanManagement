using HumanManagement.DataAccess.Models;

namespace HumanManagement.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByName(string userName);
    }
}
