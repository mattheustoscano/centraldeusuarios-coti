using CentralDeUsuarios.Infra.Logs.Models;

namespace CentralDeUsuarios.Infra.Logs.Interfaces
{
    /// <summary>
    /// Interface para operações no MongoDB para collection LogUsuarios
    /// </summary>
    public interface ILogUsuariosPersistence
    {
        void Create(LogUsuarioModel model);
        void Update(LogUsuarioModel model); 
        void Delete(LogUsuarioModel model);

        List<LogUsuarioModel> GetAll(DateTime dataMin, DateTime dataMax);
        List<LogUsuarioModel> GetAll(Guid usuarioId);
        List<LogUsuarioModel> GetAll(string email);
    }
}
