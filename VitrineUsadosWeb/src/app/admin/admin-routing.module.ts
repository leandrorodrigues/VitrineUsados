import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaComponent } from './carro/lista/lista.component';
import { NovoComponent } from './carro/novo/novo.component';
import { EditarComponent } from './carro/editar/editar.component';

const routes: Routes = [
  { path: '', redirectTo: 'carro', pathMatch: 'full' },
  { path: 'carro', component: ListaComponent },
  { path: 'carro/novo', component: NovoComponent },
  { path: 'carro/editar/:id', component: EditarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
