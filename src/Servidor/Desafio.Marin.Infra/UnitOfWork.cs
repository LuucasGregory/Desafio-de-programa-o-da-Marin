using Desafio.Marin.Dominio;

namespace Desafio.Marin.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _context;
        private bool _disposed;

        public UnitOfWork(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
