using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IUsuarioSistemaFinanceiro
{
    public interface InterfaceUsuarioSistemaFinanceiro : InterfaceGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuarioSistemaFinanceiro(int IdSistema);

        Task RemoverUsuarios(List<UsuarioSistemaFinanceiro> usuarios);

        Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario);
    }
}
