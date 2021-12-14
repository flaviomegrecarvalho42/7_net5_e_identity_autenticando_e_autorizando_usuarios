using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper,
                               UserManager<CustomIdentityUser> userManager,
                               EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastrarUsuario(CreateUsuarioDto createUsuarioDto)
        {
            User usuario = _mapper.Map<User>(createUsuarioDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createUsuarioDto.Password);
            _userManager.AddToRoleAsync(usuarioIdentity, "regular");

            if (!resultadoIdentity.Result.Succeeded)
            {
                return Result.Fail("Falha ao cadastrar o usuário");
            }

            var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
            var encodedCode = HttpUtility.UrlEncode(code);
            //_emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação de Conta", usuarioIdentity.Id, encodedCode);

            return Result.Ok().WithSuccess(code);
        }

        public Result AtivarContaUsuario(AtivaContaRequest ativaContaRequest)
        {
            var usuarioIdentity = _userManager
                .Users
                .FirstOrDefault(u => u.Id == ativaContaRequest.UserId);

            var resultadoIdentity = _userManager.ConfirmEmailAsync(usuarioIdentity, ativaContaRequest.ActivationCode).Result;

            if (!resultadoIdentity.Succeeded)
            {
                return Result.Fail("Falha ao ativar conta de usuário");
            }

            return Result.Ok();
        }
    }
}
