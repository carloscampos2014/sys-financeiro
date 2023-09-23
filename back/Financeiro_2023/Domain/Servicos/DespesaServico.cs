using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _interfaceDespesa;

        public DespesaServico(InterfaceDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            despesa.DataCadastro = DateTime.UtcNow;
            despesa.Mes = DateTime.UtcNow.Month;
            despesa.Ano = DateTime.UtcNow.Year;
            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Add(despesa);

        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            despesa.DataAlteracao = DateTime.UtcNow;
            if (despesa.Pago)
                despesa.DataPagamento = DateTime.UtcNow;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Update(despesa);
        }
    }
}
