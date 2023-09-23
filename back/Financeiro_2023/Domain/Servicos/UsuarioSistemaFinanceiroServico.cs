using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinanceiroServico
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroServico(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuariosNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            var valido = usuarioSistemaFinanceiro.ValidarPropriedadeString(usuarioSistemaFinanceiro.EmailUsuario, "EmailUsuario");
            if (valido)
                await _interfaceUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
