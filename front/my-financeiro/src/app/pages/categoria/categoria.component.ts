import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.scss']
})
export class CategoriaComponent {
  constructor(public menuService: MenuService) {

  }
  ngOnInit(): void {
    this.menuService.menuselecionado = 'categoria';
  }
}
