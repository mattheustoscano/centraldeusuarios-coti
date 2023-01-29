using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Infra.Security.Settings
{
    public class JwtSettings
    {

        /// <summary>
        /// Chave Secreta antifalsificação do TOKEN
        /// </summary>
        public string? SecretKey { get; set; }

        /// <summary>
        /// Tempo de expiração do TOKEN
        /// </summary>
        public int ExpirationInHours { get; set; }

    }
}
