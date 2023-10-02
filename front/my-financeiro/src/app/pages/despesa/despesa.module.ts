import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DespesaRoutingModule } from "./despesa-routing.module";
import { DespesaComponent } from "./despesa.component";
import { NavbarModule } from "src/app/components/navbar/navbar.module";
import { SidebarModule } from "src/app/components/sidebar/sidebar.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgSelectModule } from "@ng-select/ng-select";
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@NgModule({
  providers: [],
  declarations: [DespesaComponent],
  imports: [
    CommonModule,
    DespesaRoutingModule,
    NavbarModule,
    SidebarModule,
    ReactiveFormsModule,
    FormsModule,
    NgSelectModule,
    MatSlideToggleModule,
  ]
})

export class DespesaModule { }