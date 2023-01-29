using CentralDeUsuarios.Domain.Core;
using CentralDeUsuarios.Domain.Entities;
using CentralDeUsuarios.Domain.Interfaces.Repositories;
using CentralDeUsuarios.Domain.Interfaces.Security;
using CentralDeUsuarios.Domain.Interfaces.Services;
using CentralDeUsuarios.Domain.Models;

namespace CentralDeUsuarios.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio de usuários
    /// </summary>
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributo
        private readonly IUnitOfWork _unityOfWork;
        private readonly IAuthorizationSecurity _authorizationSecurity;

        public UsuarioDomainService(IUnitOfWork unityOfWork, IAuthorizationSecurity authorizationSecurity)
        {
            _unityOfWork = unityOfWork;
            _authorizationSecurity = authorizationSecurity;
        }

        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>

        public AuthorizationModel AutenticarUsuario(string email, string senha)
        {
            //consultar o usuário no bando de dados através do e-mail e da senha.
            var usuario = _unityOfWork.UsuarioRepository.GetByEmailAndSenha(email, senha);

            DomainException.When(usuario == null, "Acesso negado. Usuário não econtrado.");

            return new AuthorizationModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                AccessToken = _authorizationSecurity.CreateToken(usuario)
            };

        }

        /// <summary>
        /// Método para criar um usuário na aplicação
        /// </summary>
        /// <param name="usuario">Entidade de domínio</param>
        public void CriarUsuario(Usuario usuario)
        {
            //Não é permitido cadastrar usuários com o mesmo email

            DomainException.When(
                    _unityOfWork.UsuarioRepository.GetByEmail(usuario.Email) != null,
                    $"O email {usuario.Email} já está cadastrado, tente outro."
                );

            _unityOfWork.UsuarioRepository.Create(usuario);
        }

        public void Dispose()
        {
            _unityOfWork.Dispose();
        }
    }
}
