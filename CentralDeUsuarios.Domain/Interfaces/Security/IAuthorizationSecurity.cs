using CentralDeUsuarios.Domain.Entities;

namespace CentralDeUsuarios.Domain.Interfaces.Security
{    
    /// <summary>
    /// Interface para definir o contrtato de métodos para geração do TOKEN do usuário
    /// </summary>
    public interface IAuthorizationSecurity
    {
        /// <summary>
        /// Método para geração do token do usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário autenticado</param>
        /// <returns>TOKEN JWT para este usuário</returns>
        string CreateToken(Usuario usuario);
    }
}
