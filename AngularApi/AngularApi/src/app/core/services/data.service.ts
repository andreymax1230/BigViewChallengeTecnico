// data.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';

import { Product, Car, User } from '../interface/data'

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private url = 'https://localhost:7039/api';

  private userSubject = new BehaviorSubject<User | null>(null);
  user$ = this.userSubject.asObservable(); // Observable para suscribirse

  constructor(private http: HttpClient) {}

  getProducts(): Observable<any> {
    return this.http.get<any>(`${this.url}/Product`);
  }

  addCar(carItem: Car) {
    return this.http.post(`${this.url}/Car`, carItem);
  }

  getUser(): Observable<any> {
    return this.http.get<any>(`${this.url}/User`).pipe(
      tap((response) => {
        const data = response.data as User[];
        const user = data && data.length ? data[0] : null;
        this.userSubject.next(user); // Actualizamos el estado
      })
    );
  }

  // Método auxiliar para obtener el último usuario guardado
  getCurrentUser(): User | null {
    return this.userSubject.value;
  }
}