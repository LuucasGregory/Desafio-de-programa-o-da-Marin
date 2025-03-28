namespace Desafio.Marin.Dominio
{
    /// <summary>
    /// Interface para a unidade de trabalho
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
