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

        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro, ISistemaFinanceiroServico sistemaFinanceiroServico)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _sistemaFinanceiroServico = sistemaFinanceiroServico;
        }

        [Produces("application/json")]
        [HttpGet("/api/ListaSistemasUsuario")]
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListarSistemaFinanceiroUsuario(emailUsuario);
        }

        [Produces("application/json")]
        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [Produces("application/json")]
        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [Produces("application/json")]
        [HttpGet("/api/ObterSistemaFinanceiro")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _interfaceSistemaFinanceiro.GetEntityById(id);
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            var sistemaFinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);
            await _interfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarSistemaFinanceiro")]
        public async Task<object> ListarSistemaFinanceiro()
        {
            return await _interfaceSistemaFinanceiro.List();
        }
    }
}
