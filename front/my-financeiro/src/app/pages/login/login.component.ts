import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(public formBuilder: FormBuilder,
    private router: Router,
    private loginService: LoginService) {

  }

  loginForm: FormGroup;

  get dadosForm() {
    return this, this.loginForm.controls;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        senha: ['', [Validators.required]]
      }
    )
  }

  loginUser() {
    this.loginService.login(this.dadosForm["email"].value, this.dadosForm["senha"].value)
      .subscribe(
        token => {
          alert("Seja bem vindo!");
          this.router.navigate(['/dashboard']);
        },
        err => {
          alert('Ocorreu um erro');
        }
      );
  }
}