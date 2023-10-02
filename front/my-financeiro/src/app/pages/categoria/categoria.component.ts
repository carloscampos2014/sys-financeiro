import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Categoria } from 'src/app/models/Categoria';
import { SelectModel } from 'src/app/models/SelectModel';
import { SistemaFinanceiro } from 'src/app/models/SistemaFinaceiro';
import { CategoriaService } from 'src/app/services/categoria.service';
import { MenuService } from 'src/app/services/menu.service';
import { SistemaFinanceiroService } from 'src/app/services/sistemaFinanceiro.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.scss']
})

export class CategoriaComponent {
  constructor(
    public menuService: MenuService,
    public formBuilder: FormBuilder,
    public sistemaFinanceiroService: SistemaFinanceiroService,
    public categoriaService: CategoriaService) { }

  listSistemas = new Array<SelectModel>();
  sistemaSelect = new SelectModel();

  categoriaForm: FormGroup;

  get dadosForm() {
    return this, this.categoriaForm.controls;
  }

  ngOnInit(): void {
    this.CarregarSistemasFinanceiros();
    this.menuService.menuselecionado = 'categoria';
    this.menuService.paginaSelecionada = 'Cadastro de Categorias';
    this.categoriaForm = this.formBuilder.group(
      {
        nome: ['', [Validators.required]],
        idSistema: ['', [Validators.required]],
      }
    )
  }

  CarregarSistemasFinanceiros() {
    this.sistemaFinanceiroService.ListarPorUsuario()
      .subscribe((response: any) => {
        var sistemasFinanceiros = [];
        response.forEach(element => {
          let item = new SelectModel();
          item.id = element.id;
          item.name = element.nome;
          sistemasFinanceiros.push(item);
        });
        this.listSistemas = sistemasFinanceiros;
        console.log(this.listSistemas);
      });
  }

  enviar() {
    var dados = this.dadosForm;
    let categoria = new Categoria();
    categoria.IdSistema = parseInt(this.sistemaSelect.id);
    categoria.Nome = dados["nome"].value;
    this.categoriaService.Adicionar(categoria)
      .subscribe(
        (response: any) => {
          this.categoriaForm.reset();
        },
        (error) => {
          alert(`Erro: ${JSON.stringify(error)}`);
        });
  }
}
