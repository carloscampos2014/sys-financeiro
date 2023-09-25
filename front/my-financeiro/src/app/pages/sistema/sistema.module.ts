import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SistemaRoutingModule } from "./sistema-routing.module";
import { SistemaComponent } from "./sistema.component";

@NgModule({
  providers: [],
  declarations: [SistemaComponent],
  imports: [
    CommonModule,
    SistemaRoutingModule,
  ]
})

export class SistemaModule { }