using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult ConectarUsuario(LoginRequest loginRequest)
        {
            Result resultado = _loginService.ConectarUsuario(loginRequest);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }

            return Ok(resultado.Successes);
        }
    
        [HttpPost]
        [Route("/SolicitarReset")]
        public IActionResult SolicitarResetSenhaUsuario(SolicitaResetRequest solicitaResetRequest)
        {
            Result resultado = _loginService.SolicitarResetSenhaUsuario(solicitaResetRequest);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }

            return Ok(resultado.Successes);
        }

        [HttpPost]
        [Route("/EfetuarReset")]
        public IActionResult ResetarSenhaUsuario(EfetuaResetRequest efetuaResetRequest)
        {
            Result resultado = _loginService.ResetarSenhaUsuario(efetuaResetRequest);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }

            return Ok(resultado.Successes);
        }
    }
}
