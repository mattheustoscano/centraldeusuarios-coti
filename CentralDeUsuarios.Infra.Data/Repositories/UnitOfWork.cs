using CentralDeUsuarios.Domain.Interfaces.Repositories;
using CentralDeUsuarios.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace CentralDeUsuarios.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;
        private IDbContextTransaction _dbContextTransaction;

        //construtor para injeção de denpendência
        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_sqlServerContext);

        public void BeginTransaction()
        {
            _dbContextTransaction = _sqlServerContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void RollBack()
        {
            _dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }

    }
}
