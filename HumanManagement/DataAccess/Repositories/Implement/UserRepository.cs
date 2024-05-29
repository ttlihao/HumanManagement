using HumanManagement.DataAccess.Models;
using HumanManagement.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.DataAccess.Repositories.Implement
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HumanResourceContext context) : base(context)
        {
        }
        public async Task<User> GetUserByName(string userName)
        {
            try
            {
                // Assuming _context is an instance of your HumanResourceContext
                return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == userName);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database errors)
                // Log or handle the exception as needed
                // You can return null or throw a custom exception here
                // For simplicity, returning null in case of an error
                return null;
            }
        }

    }
}
