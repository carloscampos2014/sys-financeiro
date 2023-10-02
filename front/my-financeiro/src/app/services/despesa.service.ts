import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { Despesa } from "../models/Despesa";
import { AuthService } from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class DespesaService {
  private readonly baseurl = environment["endPoint"];

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService) { }

  Adicionar(despesa: Despesa) {
    return this.httpClient.post<Despesa>(`${this.baseurl}/Despesa/Adicionar`, {
      IdCategoria: despesa.IdCategoria,
      Nome: despesa.Nome,
      TipoDespesa: despesa.TipoDespesa,
      Valor: despesa.Valor,
      DataVencimento: despesa.DataVencimento,
      Pago: despesa.Pago,
      DataPagamento: despesa.DataPagamento,
    });
  }

  Atualizar(despesa: Despesa) {
    return this.httpClient.put<Despesa>(`${this.baseurl}/Despesa/Atualizar`, {
      Id: despesa.Id,
      IdCategoria: despesa.IdCategoria,
      Nome: despesa.Nome,
      TipoDespesa: despesa.TipoDespesa,
      Valor: despesa.Valor,
      DataVencimento: despesa.DataVencimento,
      Pago: despesa.Pago,
      DataPagamento: despesa.DataPagamento,
    });
  }

  Remover(id: number) {
    return this.httpClient.delete<Despesa>(`${this.baseurl}/Despesa/Remover?id=${id}`);
  }

  Obter(id: number) {
    return this.httpClient.get<Despesa>(`${this.baseurl}/Despesa/Obter?id=${id}`);
  }

  ListarPorUsuario() {
    let emailUsuario = this.authService.GetUser;
    return this.httpClient.get(`${this.baseurl}/Despesa/ListarPorUsuario?emailUsuario=${emailUsuario}`);
  }
}