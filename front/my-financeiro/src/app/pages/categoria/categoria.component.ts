import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SelectModel } from 'src/app/models/SelectModel';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.scss']
})

export class CategoriaComponent {
  constructor(
    public menuService: MenuService,
    public formBuilder: FormBuilder) {

  }

  listSistemas = new Array<SelectModel>();
  sistemaSelect = new SelectModel();

  categoriaForm: FormGroup;

  get dadosForm() {
    return this, this.categoriaForm.controls;
  }

  ngOnInit(): void {
    this.menuService.menuselecionado = 'categoria';
    this.menuService.paginaSelecionada = 'Cadastro de Categorias';
    this.categoriaForm = this.formBuilder.group(
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
