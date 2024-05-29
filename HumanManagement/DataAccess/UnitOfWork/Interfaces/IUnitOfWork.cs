using HumanManagement.DataAccess.Repositories.Interfaces;

namespace HumanManagement.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Save();
    }
}
