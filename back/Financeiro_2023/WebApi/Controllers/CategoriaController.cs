using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaController(
            InterfaceCategoria interfaceCategoria,
            ICategoriaServico categoriaServico)
        {
            _interfaceCategoria = interfaceCategoria;
            _categoriaServico = categoriaServico;
        }

        [Produces("application/json")]
        [HttpGet("ListarPorUsuario")]
        public async Task<object> ListarPorUsuario(string emailUsuario)
        {
            return await _interfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }

        [Produces("application/json")]
        [HttpGet("Obter")]
        public async Task<object> Obter(int id)
        {
            return await _interfaceCategoria.GetEntityById(id);
        }

        [Produces("application/json")]
        [HttpPost("Adicionar")]
        public async Task<object> Adicionar([FromBody] AdicionarModel model)
        {
            var novo = new Categoria()
            {
                IdSistema = model.IdSistema,
                Nome = model.Nome,
            };

            await _categoriaServico.AdicionarCategororia(novo);
            return Task.FromResult(novo);
        }

        [Produces("application/json")]
        [HttpPut("Atualizar")]
        public async Task<object> Atualizar([FromBody] Categoria model)
        {
            await _categoriaServico.AtualizarCategororia(model);
            return Task.FromResult(model);
        }

        [Produces("application/json")]
        [HttpDelete("Remover")]
        public async Task<object> Remover(int id)
        {
            var categoria = await _interfaceCategoria.GetEntityById(id);
            await _interfaceCategoria.Delete(categoria);
            return Task.FromResult(categoria);
        }
    }
}
