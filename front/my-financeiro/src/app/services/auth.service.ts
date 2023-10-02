import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private usuarioAutenticado: boolean = false;
  private token: any;
  private user: any;

  constructor(private httpClient: HttpClient) {

  }

  CheckToken() {
    return Promise.resolve(true);
  }

  UsuarioAutenticado(status: boolean) {
    localStorage.setItem('UsuarioAutenticado', JSON.stringify(status));
    this.usuarioAutenticado = status;
  }

  UsuarioEstaAutenticado(): Promise<boolean> {
    this.usuarioAutenticado = localStorage.getItem('UsuarioAutenticado') == 'true';
    return Promise.resolve(this.usuarioAutenticado);
  }

  SetToken(token: string) {
    localStorage.setItem('Token', token);
    this.token = token;
  }

  get GetToken() {
    this.token = localStorage.getItem('Token');
    return this.token;
  }

  SetUser(user: string) {
    localStorage.setItem('User', user);
    this.user = user;
  }

  get GetUser() {
    this.user = localStorage.getItem('User');
    return this.user;
  }

  LimparToken() {
    this.token = null;
    this.user = null;
  }

  LimparDadosUsuario() {
    this.UsuarioAutenticado(false);
    this.LimparToken();
    localStorage.clear();
    sessionStorage.clear();
  }

}