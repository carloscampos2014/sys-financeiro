import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DespesaRoutingModule } from "./despesa-routing.module";
import { DespesaComponent } from "./despesa.component";

@NgModule({
  providers: [],
  declarations: [DespesaComponent],
  imports: [
    CommonModule,
    DespesaRoutingModule,
  ]
})

export class DespesaModule { }