import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { UsuarioService } from '../services/usuario.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private usuarioService: UsuarioService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    
    if(this.usuarioService.estaLogado()) {
      const requestClone = request.clone({
        headers: request.headers.set('authorization', 'Bearer ' + this.usuarioService.token)
      });
      return next.handle(requestClone).pipe(catchError(e => this.trataErro(e)));
      
    }
    return next.handle(request);
  }

  private trataErro(erro: HttpErrorResponse): Observable<any> {
    if(erro.status === 401) {
      this.usuarioService.logout();
    }

    return throwError(() => erro);
  }
}
