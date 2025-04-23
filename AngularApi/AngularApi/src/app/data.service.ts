// Import Library
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import * as uuid from 'uuid';



// Import interface
import { Product, Car } from './data'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private url = 'https://localhost:7039/api'
  constructor(private http: HttpClient) { }

  getProducts(): Observable<any> 
  {
    return this.http.get<any>(`${this.url}/Product`)
  }

  addCar(carItem: Car)
  {
    return this.http.post(`${this.url}/Product`, carItem)
  }

  getUser(): Observable<any> 
  {
    return this.http.get<any>(`${this.url}/User`)
  }
}
