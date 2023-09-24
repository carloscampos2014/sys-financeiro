using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _usuarioSistemaFinanceiroServico;

        public UsuarioSistemaFinanceiroController(
            InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiroServico)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroServico = usuarioSistemaFinanceiroServico;
        }


        [Produces("application/json")]
        [HttpGet("ListarporSistemaFinanceiro")]
        public async Task<object> ListaPorSistemaFinanceiro(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuarioSistemaFinanceiro(idSistema);
        }

        [Produces("application/json")]
        [HttpPost("Adicionar")]
        public async Task<object> Adicionar([FromBody] AdicionarModel model)
        {
            var novo = new UsuarioSistemaFinanceiro()
            {
                IdSistema = model.IdSistema,
                EmailUsuario = model.EmailUsuario,
                Administrador = false,
                SistemaAtual = true,
            };

            await _usuarioSistemaFinanceiroServico.CadastrarUsuariosNoSistema(novo);

            return Task.FromResult(novo);
        }

        [Produces("application/json")]
        [HttpDelete("Remover")]
        public async Task<object> Remover(int id)
        {
            var usuario = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

            await _interfaceUsuarioSistemaFinanceiro.Delete(usuario);

            return Task.FromResult(usuario);
        }
    }
}
