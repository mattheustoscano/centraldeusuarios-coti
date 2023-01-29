using CentralDeUsuarios.Application.Commands;
using CentralDeUsuarios.Application.Interfaces;
using CentralDeUsuarios.Domain.Models;
using CentralDeUsuarios.Infra.Logs.Interfaces;
using CentralDeUsuarios.Infra.Logs.Models;
using MediatR;

namespace CentralDeUsuarios.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de aplicação
    /// </summary>
    public class UsuarioAppService : IUsuarioAppService
    {
        //atributos
        private readonly IMediator _mediatR;
        private readonly ILogUsuariosPersistence _logUsuarioPersistence;

        //construtor para injeção de dependência
        public UsuarioAppService(IMediator mediatR, ILogUsuariosPersistence logUsuarioPersistence)
        {
            _mediatR = mediatR;
            _logUsuarioPersistence = logUsuarioPersistence;
        }

        public async Task CriarUsuario(CriarUsuarioCommand command)
        {
            await _mediatR.Send(command);
        }

        public async Task<AuthorizationModel> AutenticarUsuario(AutenticarUsuarioCommand command)
        {
            return await _mediatR.Send(command);
        }

        public List<LogUsuarioModel> ConsultarLogDeUsuario(string email)
        {
            return _logUsuarioPersistence.GetAll(email);
        }
    }
}
