using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signManager, TokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public Result ConectarUsuario(LoginRequest loginRequest)
        {
            var resultadoIdentity = _signManager
                .PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, false, false);

            if (!resultadoIdentity.Result.Succeeded)
            {
                return Result.Fail("Login falhou");
            }

            CustomIdentityUser usuarioIdentity = _signManager
                .UserManager
                .Users
                .FirstOrDefault(usuario => usuario.NormalizedUserName == loginRequest.UserName.ToUpper());

            Token token = _tokenService.CreateToken(usuarioIdentity, 
                                                    _signManager.UserManager
                                                                .GetRolesAsync(usuarioIdentity)
                                                                .Result
                                                                .FirstOrDefault());

            return Result.Ok().WithSuccess(token.Value);
        }

        public Result SolicitarResetSenhaUsuario(SolicitaResetRequest solicitaResetRequest)
        {
            CustomIdentityUser usuarioIdentity = RecuperarUsuarioPorEmail(solicitaResetRequest.Email);

            if (usuarioIdentity == null)
            {
                return Result.Fail("Falha ao solicitar redefinição de senha.");
            }

            string codigoRecuperacao = _signManager
                .UserManager
                .GeneratePasswordResetTokenAsync(usuarioIdentity).Result;

            return Result.Ok().WithSuccess(codigoRecuperacao);
        }

        public Result ResetarSenhaUsuario(EfetuaResetRequest efetuaResetRequest)
        {
            CustomIdentityUser usuarioIdentity = RecuperarUsuarioPorEmail(efetuaResetRequest.Email);

            IdentityResult resultadoIdentity = _signManager
                .UserManager
                .ResetPasswordAsync(usuarioIdentity, efetuaResetRequest.Token, efetuaResetRequest.Password).Result;

            if (resultadoIdentity == null)
            {
                return Result.Fail("Falha ao redefinir senha");
            }

            return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
        }

        private CustomIdentityUser RecuperarUsuarioPorEmail(string email)
        {
            return _signManager
                            .UserManager
                            .Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
