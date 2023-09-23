using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
    {
        public async Task<IList<Categoria>> ListarCategoriasUsuarioAsync(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
