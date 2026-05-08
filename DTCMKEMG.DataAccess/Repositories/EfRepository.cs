using Ardalis.Specification.EntityFrameworkCore;
using DTCMKEMG.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DTCMKEMG.DataAccess.Repositories
{
    public class EfRepository<T> : RepositoryBase<T>, IEfRepository<T> where T : class
    {
        private readonly MiDbContext _context;
        private IDbContextTransaction? _transaction;

        public EfRepository(MiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return;
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                return;
            }
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                return;
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
