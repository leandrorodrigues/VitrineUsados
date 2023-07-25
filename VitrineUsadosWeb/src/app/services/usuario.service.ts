import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrl } from '../constants';
import { LoginRequest } from '../models/login-request';
import { LoginResponse } from '../models/login-response';
import { Usuario } from '../models/usuario';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  logado = false;
  token = '';
  usuario?: Usuario;
  logadoSubject: BehaviorSubject<boolean>;
  
  constructor(
    private http: HttpClient
  ) {
    this.logadoSubject = new BehaviorSubject(false);  
  }

  login(email: string, senha: string) {
    let request = {
      email: email,
      senha: senha
    } as LoginRequest;

    return this.http.post<LoginResponse>(`${ApiUrl}usuarios/login`, request).pipe(map(response => {
      this.guardarLogin(response.usuario, response.token);
    }));
  }

  logout() {
    this.logado = false;
    this.token = '';
    this.usuario = undefined;
    localStorage.clear();
  }

  guardarLogin(usuario: Usuario, token: string) {
    this.token = token;
    this.usuario = usuario;
    localStorage.setItem('Vitrine.Token', token);
    localStorage.setItem('Vitrine.Usuario', JSON.stringify(usuario));
    this.logado = true;
    this.logadoSubject.next(true);
  }

  estaLogado():boolean {
    if(this.logado)
      return true;

    var token = localStorage.getItem('Vitrine.Token');
    var usuario = localStorage.getItem('Vitrine.Usuario');
    if(token != null && usuario != null) {
      this.guardarLogin(JSON.parse(usuario), token);
      return true;
    }
    
    return false;
  }

}
