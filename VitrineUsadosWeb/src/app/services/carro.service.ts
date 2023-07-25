import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Carro } from '../models/carro';
import { Observable } from 'rxjs';
import { ApiUrl } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class CarroService {

  constructor
  (
    private http: HttpClient
  ) {
    
  }

  todos(): Observable<Carro[]> {
    return this.http.get<Carro[]>(`${ApiUrl}carros`);
  }

  obter(id: number): Observable<Carro> {
    return this.http.get<Carro>(`${ApiUrl}carros/` + id);
  }

  excluir(id: number) {
    return this.http.delete(`${ApiUrl}carros/` + id);
  }

  salvar(carro: Carro): Observable<Carro> {
    return this.http.post<Carro>(`${ApiUrl}carros`, carro);
  }

  editar(carro: Carro): Observable<Carro> {
    return this.http.put<Carro>(`${ApiUrl}carros/` + carro.id, carro);
  }

}
