using Desafio.Marin.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Marin.Infra
{
    /// <summary>
    /// Repositório de transações
    /// </summary>
    public class TransacaoRepository : ITransacaoRepository
    {
        private IDatabaseContext _databaseContext;

        public TransacaoRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<List<Transacao>> BuscarTodosAsync(CancellationToken cancellationToken)
        {
            return _databaseContext.Set<Transacao>().ToListAsync(cancellationToken);
        }

        public Task InserirAsync(IList<Transacao> transacao, CancellationToken cancellationToken)
        {
            return _databaseContext.Set<Transacao>().AddRangeAsync(transacao.ToArray(), cancellationToken);
        }
    }
}
