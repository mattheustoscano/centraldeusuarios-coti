using CentralDeUsuarios.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeUsuarios.Services.Api.Controllers
{
    [Authorize(Roles = "DEFAULT")]
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public LogsController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var emailUsuario = User.Identity.Name;
            var logs = _usuarioAppService.ConsultarLogDeUsuario(emailUsuario);

            //TODO
            return StatusCode(200, logs);
        }
    }
}
