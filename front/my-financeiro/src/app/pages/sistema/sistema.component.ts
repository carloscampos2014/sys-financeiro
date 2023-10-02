import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SistemaFinanceiro } from 'src/app/models/SistemaFinaceiro';
import { MenuService } from 'src/app/services/menu.service';
import { SistemaFinanceiroService } from 'src/app/services/sistemaFinanceiro.service';

@Component({
  selector: 'app-sistema',
  templateUrl: './sistema.component.html',
  styleUrls: ['./sistema.component.scss']
})

export class SistemaComponent {
  constructor(
    public menuService: MenuService,
    public formBuilder: FormBuilder,
    public sistemaFinanceiroService: SistemaFinanceiroService) {

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
    var dados = this.dadosForm;
    let sistema = new SistemaFinanceiro();
    sistema.Nome = dados["nome"].value;
    this.sistemaFinanceiroService.Adicionar(sistema)
      .subscribe(
        (response: any) => {
          let sistema = response.result;
          this.enviarUsuario(sistema.id);
        },
        (error) => {
          alert(`Erro: ${JSON.stringify(error)}`);
        }
      );
  }

  enviarUsuario(id: number) {
    this.sistemaFinanceiroService.AdicionarUsuario(id)
      .subscribe(
        (response: any) => {
          this.sistemaForm.reset();
        },
        (error) => {
          alert(`Erro: ${JSON.stringify(error)
            }`);
        }
      );
  }
}
