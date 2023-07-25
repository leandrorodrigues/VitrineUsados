import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrl } from '../constants';
import { LoginRequest } from '../models/login-request';
import { LoginResponse } from '../models/login-response';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  logado = false;
  token = '';
  usuario?: Usuario;
  
  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  login(email: string, senha: string) {
    let request = {
      email: email,
      senha: senha
    } as LoginRequest;

    this.http.post<LoginResponse>(`${ApiUrl}usuarios/login`, request).subscribe({
      next: (response: LoginResponse) => {
        this.guardarLogin(response.usuario, response.token);
        this.router.navigateByUrl('/admin');
      },
      error: (error) => {
        alert('Usuario ou senha inválidos');
      }
    });
  }

  logout() {
    this.logado = false;
    this.token = '';
    this.usuario = undefined;
    localStorage.clear();
    this.router.navigateByUrl('/login');
  }

  guardarLogin(usuario: Usuario, token: string) {
    this.token = token;
    this.usuario = usuario;
    localStorage.setItem('Vitrine.Token', token);
    localStorage.setItem('Vitrine.Usuario', JSON.stringify(usuario));
    this.logado = true;
  }

  estaLogado():boolean {
    if(this.logado)
      return true;

    var token = localStorage.getItem('Vitrine.Token');
    var usuario = localStorage.getItem('Vitrine.Usuario');
    if(token != null && usuario != null) {
      this.token = token;
      this.usuario = JSON.parse(usuario);
      this.logado = true;
      return true;
    }
    
    return false;
  }

}
