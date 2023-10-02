using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Servicos;
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
    public class DespesaController : ControllerBase
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        private readonly IDespesaServico _despesaServico;

        public DespesaController(
            InterfaceDespesa interfaceDespesa,
            IDespesaServico despesaServico)
        {
            _interfaceDespesa = interfaceDespesa;
            _despesaServico = despesaServico;
        }

        [Produces("application/json")]
        [HttpGet("ListarPorUsuario")]
        public async Task<object> ListarPorUsuario(string emailUsuario)
        {
            return await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
        }

        [Produces("application/json")]
        [HttpGet("CarregarGraficos")]
        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            return await _despesaServico.CarregarGraficos(emailUsuario);
        }

        [Produces("application/json")]
        [HttpGet("ListarNaoPagasMesesAnteriores")]
        public async Task<object> ListarNaoPagasMesesAnteriores(string emailUsuario)
        {
            return await _interfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnteriores(emailUsuario);
        }

        [Produces("application/json")]
        [HttpGet("Obter")]
        public async Task<object> Obter(int id)
        {
            return await _interfaceDespesa.GetEntityById(id);
        }

        [Produces("application/json")]
        [HttpPost("Adicionar")]
        public async Task<object> Adicionar([FromBody] AdicionarModel model)
        {
            var novo = new Despesa()
            {
                IdCategoria  = model.IdCategoria,
                Nome = model.Nome,
                Valor = model.Valor,
                TipoDespesa = model.TipoDespesa,
                DataVencimento = model.DataVencimento,
                Pago = model.Pago,
            };

            if (novo.Pago)
                novo.DataPagamento = model.DataPagamento;

            await _despesaServico.AdicionarDespesa(novo);

            return Task.FromResult(novo);
        }

        [Produces("application/json")]
        [HttpPut("Atualizar")]
        public async Task<object> Atualizar([FromBody] Despesa model)
        {
            await _despesaServico.AtualizarDespesa(model);
            return Task.FromResult(model);
        }

        [Produces("application/json")]
        [HttpDelete("Remover")]
        public async Task<object> Remover(int id)
        {
            var model = await _interfaceDespesa.GetEntityById(id);
            await _interfaceDespesa.Delete(model);
            return Task.FromResult(model);
        }
    }
}
