import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Carro } from 'src/app/models/carro';
import { CarroService } from 'src/app/services/carro.service';

@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html',
  styleUrls: ['./novo.component.scss']
})
export class NovoComponent {
  carro = new Carro;

  constructor(
    private service: CarroService,
    private router: Router
  ) {}

  salvar() {
    this.service.salvar(this.carro).subscribe({
      next: () => {
        alert("Carro salvo com sucesso!");
        this.router.navigateByUrl("/admin/carro")
      },
      error: () => {
        alert("Erro ao salvar carro");
      }
    });
  }

  obterFoto(ev: any) {
    for(let file of ev.target.files) {
      const reader = new FileReader();
      reader.onloadend = (e: any)  => {
        this.carro.foto = e.target.result;
      }
      reader.readAsDataURL(file);
    }
  }
}
