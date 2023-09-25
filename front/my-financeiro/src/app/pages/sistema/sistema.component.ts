import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-sistema',
  templateUrl: './sistema.component.html',
  styleUrls: ['./sistema.component.scss']
})
export class SistemaComponent {
  constructor(public menuService: MenuService) {

  }
  ngOnInit(): void {
    this.menuService.menuselecionado = 'sistema';
    this.menuService.paginaSelecionada = 'Cadastro de Sistemas Financeiros';
  }
}
