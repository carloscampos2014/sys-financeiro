import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { SistemaFinanceiro } from "../models/SistemaFinaceiro";
import { AuthService } from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class SistemaFinanceiroService {
  private readonly baseurl = environment["endPoint"];

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService) { }

  Adicionar(sistemaFincanceiro: SistemaFinanceiro) {
    return this.httpClient.post<SistemaFinanceiro>(`${this.baseurl}/SistemaFinanceiro/Adicionar`, {
      Nome: sistemaFincanceiro.Nome
    });
  }

  AdicionarUsuario(idSistema: number) {
    let emailUsuario = this.authService.GetUser;
    return this.httpClient.post<any>(`${this.baseurl}/UsuarioSistemaFinanceiro/Adicionar`, {
      IdSistema: idSistema,
      EmailUsuario: emailUsuario,
    });
  }

  Atualizar(sistemaFincanceiro: SistemaFinanceiro) {
    return this.httpClient.put<SistemaFinanceiro>(`${this.baseurl}/SistemaFinanceiro/Atualizar`, {
      Id: sistemaFincanceiro.Id,
      Nome: sistemaFincanceiro.Nome,
    });
  }

  Remover(id: number) {
    return this.httpClient.delete<SistemaFinanceiro>(`${this.baseurl}/SistemaFinanceiro/Remover?id=${id}`);
  }

  Obter(id: number) {
    return this.httpClient.get<SistemaFinanceiro>(`${this.baseurl}/SistemaFinanceiro/Obter?id=${id}`);
  }

  ListarPorUsuario() {
    let emailUsuario = this.authService.GetUser;
    return this.httpClient.get(`${this.baseurl}/SistemaFinanceiro/ListarPorUsuario?emailUsuario=${emailUsuario}`);
  }
}