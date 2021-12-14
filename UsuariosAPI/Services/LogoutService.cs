using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signManager;

        public LogoutService(SignInManager<CustomIdentityUser> signManager)
        {
            _signManager = signManager;
        }

        public Result DesconectarUsuario()
        {
            var resultadoIdentity = _signManager.SignOutAsync();

            if (!resultadoIdentity.IsCompletedSuccessfully)
            {
                return Result.Fail("Logout falhou");
            }

            return Result.Ok();
        }
    }
}
