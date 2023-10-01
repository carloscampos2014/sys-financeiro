import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from 'src/app/services/menu.service';
import { SelectModel } from '../../models/SelectModel';

@Component({
  selector: 'app-despesa',
  templateUrl: './despesa.component.html',
  styleUrls: ['./despesa.component.scss']
})
export class DespesaComponent {
  constructor(
    public menuService: MenuService,
    public formBuilder: FormBuilder) {

  }

  listCategorias = new Array<SelectModel>();
  categoriaSelect = new SelectModel();

  listTipoDespesa = new Array<SelectModel>();
  tipoDespesaSelect = new SelectModel();

  despesaForm: FormGroup;

  get dadosForm() {
    return this, this.despesaForm.controls;
  }

  ngOnInit(): void {
    this.menuService.menuselecionado = 'despesa';
    this.menuService.paginaSelecionada = 'Cadastro de Despesas';
    this.despesaForm = this.formBuilder.group(
      {
        nome: ['', [Validators.required]],
        valor: ['0', [Validators.required, Validators.min(0.01)]],
        data: ['', [Validators.required]]
      }
    )
  }

  enviar() {
    debugger
    var dados = this.dadosForm;
    alert(dados["nome"].value);
  }
}
