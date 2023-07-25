import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaComponent } from './lista/lista.component';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';

@NgModule({
  declarations: [
    ListaComponent
  ],
  imports: [
    CommonModule,
    MatCardModule, 
    MatButtonModule,
    MatGridListModule
  ]
})
export class CarroModule { }
