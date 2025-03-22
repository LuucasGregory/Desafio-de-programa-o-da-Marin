using Desafio.Marin.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Marin.Infra
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private IDatabaseContext _databaseContext;

        public TransacaoRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IList<Transacao>> BuscarTodos()
        {
            return await _databaseContext.Set<Transacao>().ToListAsync();
        }

        public async Task<Transacao> Inserir(Transacao transacao)
        {
            var entityEntry = await _databaseContext.Set<Transacao>().AddAsync(transacao);

            return entityEntry.Entity;
        }
    }
}
