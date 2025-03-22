namespace Desafio.Marin.Dominio
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
