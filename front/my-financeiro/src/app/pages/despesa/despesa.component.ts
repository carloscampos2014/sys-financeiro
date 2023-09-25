import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-despesa',
  templateUrl: './despesa.component.html',
  styleUrls: ['./despesa.component.scss']
})
export class DespesaComponent {
  constructor(public menuService: MenuService) {

  }
  ngOnInit(): void {
    this.menuService.menuselecionado = 'despesa';
  }
}
