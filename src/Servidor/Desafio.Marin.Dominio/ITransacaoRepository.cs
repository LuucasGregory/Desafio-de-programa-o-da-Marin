namespace Desafio.Marin.Dominio
{
    public interface ITransacaoRepository
    {
        Task<Transacao> InserirAsync(Transacao transacao);
        Task<IList<Transacao>> BuscarTodosAsync();

        Task SaveChangesAsync();
    }
}
