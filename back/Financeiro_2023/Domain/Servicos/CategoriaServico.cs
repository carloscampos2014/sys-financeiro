using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        
        public CategoriaServico(InterfaceCategoria interfaceCategoria)
        {
            _interfaceCategoria = interfaceCategoria;
        }

        public async Task AdicionarCategororia(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if (valido)
                await _interfaceCategoria.Add(categoria);
        }

        public async Task AtualizarCategororia(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if (valido)
                await _interfaceCategoria.Update(categoria);
        }
    }
}
