namespace Desafio.Marin.Dominio
{
    /// <summary>
    /// Interface para o repositório de transações
    /// </summary>
    public interface ITransacaoRepository
    {
        Task<Transacao> InserirAsync(Transacao transacao);
        Task<IList<Transacao>> BuscarTodosAsync();
    }
}
