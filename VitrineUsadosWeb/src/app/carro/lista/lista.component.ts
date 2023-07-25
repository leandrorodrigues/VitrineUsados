import { Component, OnInit } from '@angular/core';
import { Carro } from 'src/app/models/carro';
import { CarroService } from 'src/app/services/carro.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit  {
  carros?:Carro[];

  constructor(
    private service: CarroService
  ) {

  }

  ngOnInit(): void {
    this.service.todos().subscribe(carros => this.carros = carros );
  }
}
