namespace Desafio.Marin.Dominio
{
    /// <summary>
    /// Interface para o repositório de transações
    /// </summary>
    public interface ITransacaoRepository
    {
        Task InserirAsync(IList<Transacao> transacao, CancellationToken cancellationToken);
        Task<List<Transacao>> BuscarTodosAsync(CancellationToken cancellationToken);
    }
}
