import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { Categoria } from "../models/Categoria";
import { AuthService } from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  private readonly baseurl = environment["endPoint"];

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService) { }

  Adicionar(categoria: Categoria) {
    return this.httpClient.post<Categoria>(`${this.baseurl}/Categoria/Adicionar`, {
      IdSistema: categoria.IdSistema,
      Nome: categoria.Nome,
    });
  }

  Atualizar(categoria: Categoria) {
    return this.httpClient.put<Categoria>(`${this.baseurl}/Categoria/Atualizar`, {
      Id: categoria.Id,
      IdSistema: categoria.IdSistema,
      Nome: categoria.Nome,
    });
  }

  Remover(id: number) {
    return this.httpClient.delete<Categoria>(`${this.baseurl}/Categoria/Remover?id=${id}`);
  }

  Obter(id: number) {
    return this.httpClient.get<Categoria>(`${this.baseurl}/Categoria/Obter?id=${id}`);
  }

  ListarPorUsuario() {
    let emailUsuario = this.authService.GetUser;
    return this.httpClient.get(`${this.baseurl}/Categoria/ListarPorUsuario?emailUsuario=${emailUsuario}`);
  }
}