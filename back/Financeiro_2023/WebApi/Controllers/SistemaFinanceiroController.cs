using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroServico _sistemaFinanceiroServico;

        public SistemaFinanceiroController(
            InterfaceSistemaFinanceiro interfaceSistemaFinanceiro,
            ISistemaFinanceiroServico sistemaFinanceiroServico)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _sistemaFinanceiroServico = sistemaFinanceiroServico;
        }


        [Produces("application/json")]
        [HttpGet("Listar")]
        public async Task<object> Listar()
        {
            return await _interfaceSistemaFinanceiro.List();
        }

        [Produces("application/json")]
        [HttpGet("ListarPorUsuario")]
        public async Task<object> ListarPorUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListarSistemaFinanceiroUsuario(emailUsuario);
        }

        [Produces("application/json")]
        [HttpGet("Obter")]
        public async Task<object> Obter(int id)
        {
            return await _interfaceSistemaFinanceiro.GetEntityById(id);
        }

        [Produces("application/json")]
        [HttpPost("Adicionar")]
        public async Task<object> Adicionar(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [Produces("application/json")]
        [HttpPut("Atualizar")]
        public async Task<object> Atualizar(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [Produces("application/json")]
        [HttpDelete("Remover")]
        public async Task<object> Remover(int id)
        {
            var sistemaFinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);
            await _interfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }
    }
}
