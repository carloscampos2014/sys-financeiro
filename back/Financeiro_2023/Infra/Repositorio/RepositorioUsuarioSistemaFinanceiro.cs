using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuarioSistemaFinanceiroAsync(int IdSistema)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmailAsync(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverUsuariosAsync(List<UsuarioSistemaFinanceiro> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
