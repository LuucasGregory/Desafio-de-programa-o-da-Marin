﻿//implementação de repositorio


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

        public async Task<IList<Transacao>> BuscarTodosAsync()
        {
            return await _databaseContext.Set<Transacao>().ToListAsync();
        }

        public async Task<Transacao> InserirAsync(Transacao transacao)
        {
            var entityEntry = await _databaseContext.Set<Transacao>().AddAsync(transacao);

            return entityEntry.Entity;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
