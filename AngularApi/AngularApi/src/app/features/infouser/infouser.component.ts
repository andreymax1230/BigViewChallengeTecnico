import { Component, OnInit } from '@angular/core';
import { User } from '../../core/interface/data'
import { DataService } from '../../core/services/data.service'

@Component({
  selector: 'app-infouser',
  templateUrl: './infouser.component.html',
  styleUrl: './infouser.component.css'
})
export class InfouserComponent implements OnInit {
  user = {} as User;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.dataService.getUser().subscribe((response) => {
      // Ya se guarda el user en el servicio dentro de getUser()
    });

    this.dataService.user$.subscribe((user) => {
      if (user) {
        this.user = user;
      }
    });
  }
}

