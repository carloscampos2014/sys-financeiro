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

  id: string;
  tipoTela: number = 1; //1-Listagem 2-Cadastro 3-Edição
  tableList: Array<SistemaFinanceiro>;

  page: number = 1;
  config: any;
  paginacao: boolean = true;
  itemsPorPagina: number = 10;

  sistemaForm: FormGroup;

  get dadosForm() {
    return this, this.sistemaForm.controls;
  }

  ngOnInit(): void {
    this.menuService.menuselecionado = 'sistema';
    this.menuService.paginaSelecionada = 'Cadastro de Sistemas Financeiros';
    this.configPage();
    this.listar();
    this.sistemaForm = this.formBuilder.group(
      {
        nome: ['', [Validators.required]]
      }
    )
  }

  configPage() {
    this.id = this.gerarIdParaConfigDePagina();
    this.config = {
      id: this.id,
      currentPage: this.page,
      itemsPerPage: this.itemsPorPagina,
    };
  }

  gerarIdParaConfigDePagina() {
    var result = '';
    var charaters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charatersLenght = charaters.length;

    for (let index = 0; index < 10; index++) {
      result += charaters.charAt(Math.floor(Math.random() * charatersLenght));
    }

    return result;
  }

  listar() {
    this.tipoTela = 1;
    this.sistemaFinanceiroService.ListarPorUsuario()
      .subscribe(
        (response: Array<SistemaFinanceiro>) => {
          this.tableList = response;
        },
        (error) => {
          alert(`Você foi deslogado.`);
        }
      );
  }

  cadastro() {
    this.tipoTela = 2;
    this.sistemaForm.reset();

  }

  enviar() {
    var dados = this.dadosForm;
    let sistema = new SistemaFinanceiro();
    sistema.nome = dados["nome"].value;
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
