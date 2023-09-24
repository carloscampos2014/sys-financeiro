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

        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            var despesasUsuarios = await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
            var despesasNaoPagas = await _interfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnteriores(emailUsuario);
            var valorDespesasNaoPagas = despesasNaoPagas.Sum(s => s.Valor);
            var valorDespesasPagas = despesasUsuarios
                .Where(w => w.Pago && w.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(s => s.Valor);
            var valorDespesasPendentes = despesasUsuarios
                .Where(w => !w.Pago && w.TipoDespesa == Entities.Enums.EnumTipoDespesa.Contas)
                .Sum(s => s.Valor);
            var valorInvestimentos = despesasUsuarios
                .Where(w => w.TipoDespesa == Entities.Enums.EnumTipoDespesa.Investimento)
                .Sum(s => s.Valor);

            return new {
                Sucesso = "OK",
                DespesasNaoPagas = valorDespesasNaoPagas,
                DespesasPagas = valorDespesasPagas,
                DespesasPendentes = valorDespesasPendentes,
                Investimento = valorInvestimentos,
            };
        }
    }
}
