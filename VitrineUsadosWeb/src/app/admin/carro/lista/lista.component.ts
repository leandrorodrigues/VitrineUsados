
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Carro } from 'src/app/models/carro';
import { CarroService } from 'src/app/services/carro.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
})
export class ListaComponent implements OnInit  {

  datasource = new MatTableDataSource<Carro>([]);
  displayedColumns: string[] = ['id', 'nome',  'marca', 'modelo', 'acoes'];
 

  constructor(
    private service: CarroService,
    private router: Router,
  ) {

  }

  ngOnInit(): void {
    this.service.todos().subscribe(carros => this.datasource.data = carros );
  }

  cadastrar() {
    this.router.navigateByUrl("admin/carro/novo");
  }

  editar(id: number) {
    this.router.navigateByUrl("admin/carro/editar/" + id);
  }

  excluir(carro: Carro) {
    if(confirm("Deseja Excluir " + carro.nome + " (" + carro.id + ")?")) {
      this.service.excluir(carro.id as number).subscribe({
        next: () => {
          let carrosSobraram = this.datasource.data.filter(c => c.id != carro.id);
          this.datasource = new MatTableDataSource(carrosSobraram);
        },
        error: () => alert("Ocorreu um erro ao excluir.")
      });
    }
  }

}
