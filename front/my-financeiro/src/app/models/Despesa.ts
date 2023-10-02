export class Despesa {
  Id: number;
  IdCategoria: number;
  TipoDespesa: number;
  Nome: string;
  Mes: number;
  Ano: number;
  DataCadasto: Date;
  DataAlteracao: Date;
  DataPagamento: Date;
  DataVencimento: Date;
  Valor: number;
  Pago: boolean;
  DespesaAtrasada: boolean;
}