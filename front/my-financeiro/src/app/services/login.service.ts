import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  constructor(private httpClient: HttpClient) {

  }

  private readonly baseurl = environment["endPoint"];

  login(email: string, senha: string) {
    return this.httpClient.post<any>(`${this.baseurl}/Token/CreateToken`, { Email: email, Senha: senha });
  }
}