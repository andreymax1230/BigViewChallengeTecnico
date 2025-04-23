import { Component, OnInit } from '@angular/core';
import { Product, User, Car } from '../../core/interface/data'
import { DataService } from '../../core/services/data.service'

@Component({
  selector: 'app-infoproduct',
  templateUrl: './infoproduct.component.html',
  styleUrl: './infoproduct.component.css'
})
export class InfoproductComponent implements OnInit {
  datos: Product[] = [];
  user = {} as User;
  productDetail = {} as Product;
  isShowDetailCar = false;
  cartMessage = '';

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.dataService.getProducts().subscribe((datos) => {
      this.datos = datos.data;
    });

    this.dataService.user$.subscribe((user) => {
      if (user) {
        this.user = user;
      }
    });
  }

  addCar(userId: string, productId: string, count: number): void {
    const carItem = {
      userId: userId,
      productId: productId,
      count: count
    } as Car;

    this.dataService.addCar(carItem).subscribe((response) => {
      this.cartMessage = '¡Producto agregado al carrito exitosamente!';
      setTimeout(() => (this.cartMessage = ''), 3000);
    });
  }

  addToCart(product: Product): void {
    if (this.user && this.user.id) {
      this.addCar(this.user.id, product.id, 1);
    } else {
      this.cartMessage = 'Error: Usuario no encontrado';
      setTimeout(() => (this.cartMessage = ''), 3000);
    }
  }

  showDetailCar(itemCar: any): void {
    this.isShowDetailCar = true;
    this.productDetail = itemCar as Product;
  }
}
