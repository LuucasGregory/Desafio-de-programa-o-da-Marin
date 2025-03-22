namespace Desafio.Marin.Dominio
{
    public interface ITransacaoRepository
    {
        Task<Transacao> Inserir(Transacao transacao);
        Task<IList<Transacao>> BuscarTodos();
    }
}
