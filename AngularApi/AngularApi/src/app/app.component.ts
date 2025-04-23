import { Component } from '@angular/core';
//Interface data
import { Product, Car, User } from './core/interface/data'
// Import servicio data
import { DataService } from './core/services/data.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent 
{
  constructor(private dataService: DataService) {}
  
  ngOnInit(): void
  {

  }
  
}