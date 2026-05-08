using Ardalis.Specification;


public interface IEfRepository<T> : IRepositoryBase<T> where T : class
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
