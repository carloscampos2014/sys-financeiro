import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-sistema',
  templateUrl: './sistema.component.html',
  styleUrls: ['./sistema.component.scss']
})

export class SistemaComponent {
  constructor(
    public menuService: MenuService,
    public formBuilder: FormBuilder) {

  }

  sistemaForm: FormGroup;

  get dadosForm() {
    return this, this.sistemaForm.controls;
  }

  ngOnInit(): void {
    this.menuService.menuselecionado = 'sistema';
    this.menuService.paginaSelecionada = 'Cadastro de Sistemas Financeiros';
    this.sistemaForm = this.formBuilder.group(
      {
        nome: ['', [Validators.required]]
      }
    )
  }

  enviar() {
    debugger
    var dados = this.dadosForm;
    alert(dados["nome"].value);
  }
}
