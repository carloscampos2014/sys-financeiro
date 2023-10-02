import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent {
  constructor(
    private router: Router,
    public menuServico: MenuService,
    public authService: AuthService) {

  }

  selectMenu(menu: string) {
    if (menu == 'sair') {
      this.authService.LimparDadosUsuario();
      this.router.navigate([`/login`]);
    } else {
      this.router.navigate([`/${menu}`]);
    }
  }
}
