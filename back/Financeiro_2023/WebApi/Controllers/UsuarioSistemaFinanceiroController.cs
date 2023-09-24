using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _usuarioSistemaFinanceiroServico;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiroServico)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroServico = usuarioSistemaFinanceiroServico;
        }


        [Produces("application/json")]
        [HttpGet("/api/ListaUsuariosSistemaFinanceiro")]
        public async Task<object> ListaUsuariosSistemaFinanceiro(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuarioSistemaFinanceiro(idSistema);
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastroUsuariosSistemaFinanceiro")]
        public async Task<object> CadastroUsuariosSistemaFinanceiro(int idSistema, string emailUsuario)
        {
            var novo = new UsuarioSistemaFinanceiro()
            {
                IdSistema = idSistema,
                EmailUsuario = emailUsuario,
                Administrador = false,
                SistemaAtual = true,
            };

            await _usuarioSistemaFinanceiroServico.CadastrarUsuariosNoSistema(novo);

            return Task.FromResult(novo);
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteUsuariosSistemaFinanceiro")]
        public async Task<object> DeleteUsuariosSistemaFinanceiro(int id)
        {
            var usuario = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

            await _interfaceUsuarioSistemaFinanceiro.Delete(usuario);

            return Task.FromResult(usuario);
        }
    }
}
