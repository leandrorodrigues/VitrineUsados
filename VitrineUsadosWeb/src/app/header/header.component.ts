import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../models/usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  
  estaLogado = false;
  usuario?: Usuario;

  constructor(
    private usuarioService: UsuarioService,
    private router: Router
  ){}

  ngOnInit(): void {
    this.usuarioService.logadoSubject.subscribe(() => {
      this.estaLogado = this.usuarioService.estaLogado();
      if(this.estaLogado) {
        this.usuario = this.usuarioService.usuario;
      }
    });
  }

  logout() {
    this.usuarioService.logout();
    this.estaLogado = false;
    this.usuario = undefined;
    this.router.navigateByUrl("/");
  }

}
