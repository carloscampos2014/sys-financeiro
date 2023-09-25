import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent {
  constructor(private router: Router, public menuServico: MenuService) {

  }

  selectMenu(menu: string) {
    this.router.navigate([`/${menu}`]);
    this.menuServico.menuselecionado = menu;
  }
}
