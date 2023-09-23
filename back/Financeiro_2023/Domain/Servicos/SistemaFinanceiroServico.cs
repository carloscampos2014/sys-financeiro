using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class SistemaFinanceiroServico : ISistemaFinanceiroServico
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;

        public SistemaFinanceiroServico(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }

        public async Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            sistemaFinanceiro.DiaFechamento = 1;
            sistemaFinanceiro.Ano = DateTime.UtcNow.Year;
            sistemaFinanceiro.Mes = DateTime.UtcNow.Month;
            sistemaFinanceiro.AnoCopia = DateTime.UtcNow.Year;
            sistemaFinanceiro.MesCopia = DateTime.UtcNow.Month;
            sistemaFinanceiro.GerarCopiaDespesa = true;

            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valido)
                await _interfaceSistemaFinanceiro.Add(sistemaFinanceiro);
        }

        public async Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            sistemaFinanceiro.DiaFechamento = 1;

            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valido)
                await _interfaceSistemaFinanceiro.Update(sistemaFinanceiro);
        }
    }
}
