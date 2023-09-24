using System.Text;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha) ||
                string.IsNullOrWhiteSpace(login.CPF))
            {
                return BadRequest("Dados inválidos.");
            }

            var user = new ApplicationUser()
            {
                Email = login.Email,
                UserName = login.Email,
                CPF = login.CPF,
            };

            var result = await _userManager.CreateAsync(user, login.Senha);
            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            //Geração de Confirmação
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_Return = await _userManager.ConfirmEmailAsync(user, code);

            if(response_Return.Errors.Any())
            {
                return BadRequest(response_Return.Errors);
            }

            return Ok("Usuário Adicionado com Sucesso.");
        }
    }
}
