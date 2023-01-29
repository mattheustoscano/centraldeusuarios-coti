namespace CentralDeUsuarios.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Unidade de Trabalho do nosso repositório
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void RollBack();

        IUsuarioRepository UsuarioRepository { get; }

    }
}
