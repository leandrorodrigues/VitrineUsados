import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Carro } from 'src/app/models/carro';
import { CarroService } from 'src/app/services/carro.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.scss']
})
export class EditarComponent implements OnInit {
  carro = new Carro;

  constructor(
    private service: CarroService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      var id = Number(param.get('id'));
      this.carregar(id);
    });
  }

  carregar(id: number) {
    this.service.obter(id).subscribe((carro) => {
      this.carro = carro;
    });
  }

  salvar() {
    this.service.editar(this.carro).subscribe({
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
