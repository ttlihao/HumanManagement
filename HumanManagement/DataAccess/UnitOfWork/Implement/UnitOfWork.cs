using HumanManagement.DataAccess.Models;
using HumanManagement.DataAccess.Repositories.Interfaces;
using HumanManagement.DataAccess.UnitOfWork.Interfaces;

namespace HumanManagement.DataAccess.UnitOfWork.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HumanResourceContext _dbContext;
        public IUserRepository Users { get; }

        public UnitOfWork(HumanResourceContext dbContext,
                            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            Users = userRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
