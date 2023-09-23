using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.IDespesa;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        public async Task<IList<Despesa>> ListarDespesasUsuarioAsync(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterioresAsync(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
