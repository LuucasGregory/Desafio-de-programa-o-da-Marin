using Desafio.Marin.Dominio;

namespace Desafio.Marin.Infra
{
    /// <summary>
    /// Classe que implementa a interface IUnitOfWork, usada para salvar as alterações no banco de dados.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _context;
        private bool _disposed;

        public UnitOfWork(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
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
