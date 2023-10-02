import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { Despesa } from 'src/app/models/Despesa';
import { CategoriaService } from 'src/app/services/categoria.service';
import { DespesaService } from 'src/app/services/despesa.service';
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
    public formBuilder: FormBuilder,
    public categoriaService: CategoriaService,
    public despesaService: DespesaService) { }

  listCategorias = new Array<SelectModel>();
  categoriaSelect = new SelectModel();

  listTipoDespesa = new Array<SelectModel>();
  tipoDespesaSelect = new SelectModel();

  color = 'accent';
  checked = false;
  disabled = false;

  despesaForm: FormGroup;

  get dadosForm() {
    return this, this.despesaForm.controls;
  }

  handleChangePago(item: any) {
    this.checked = item.checked as boolean;
  }

  ngOnInit(): void {
    this.CarregarCategorias();
    this.CarregarTiposDespesas();
    this.menuService.menuselecionado = 'despesa';
    this.menuService.paginaSelecionada = 'Cadastro de Despesas';
    this.despesaForm = this.formBuilder.group(
      {
        nome: ['', [Validators.required]],
        valor: ['0', [Validators.required, Validators.min(0.01)]],
        data: ['', [Validators.required]],
        datapagamento: [''],
        idCategoria: ['', [Validators.required]],
        tipoDespesa: ['', [Validators.required]],
      }
    )
  }

  CarregarCategorias() {
    this.categoriaService.ListarPorUsuario()
      .subscribe((response: any) => {
        var categorias = [];
        response.forEach(element => {
          let item = new SelectModel();
          item.id = element.id;
          item.name = element.nome;
          categorias.push(item);
        });
        this.listCategorias = categorias;
      });
  }

  CarregarTiposDespesas() {
    var tipos = [];
    let item = new SelectModel();
    item.id = "1";
    item.name = "Contas";
    tipos.push(item);
    item = new SelectModel();
    item.id = "2";
    item.name = "Investimentos";
    tipos.push(item);
    this.listTipoDespesa = tipos;
  }

  enviar() {
    var dados = this.dadosForm;
    let despesa = new Despesa();
    despesa.IdCategoria = parseInt(this.categoriaSelect.id);
    despesa.TipoDespesa = parseInt(this.tipoDespesaSelect.id);
    despesa.Nome = dados["nome"].value;
    despesa.Valor = parseFloat(dados["valor"].value);
    despesa.DataVencimento = dados["data"].value;
    despesa.Pago = this.checked;
    despesa.DataPagamento = dados["datapagamento"].value;
    this.despesaService.Adicionar(despesa)
      .subscribe(
        (response: any) => {
          this.despesaForm.reset();
          this.checked = false;
        },
        (error) => {
          alert(`Erro: ${JSON.stringify(error)}`);
        });
  }
}
