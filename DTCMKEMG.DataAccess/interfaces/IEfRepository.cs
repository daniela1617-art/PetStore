using Ardalis.Specification;

namespace DTCMKEMG.DataAccess.interfaces;


public interface IEfRepository<T> : IRepositoryBase<T> where T : class
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
