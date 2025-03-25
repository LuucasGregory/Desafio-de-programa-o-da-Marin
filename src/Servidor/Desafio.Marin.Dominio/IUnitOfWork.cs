// unidade de trabalho"auto-explicativo"


namespace Desafio.Marin.Dominio
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
