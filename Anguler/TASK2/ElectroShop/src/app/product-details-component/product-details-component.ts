import { Component } from '@angular/core';

@Component({
  selector: 'app-product-details-component',
  standalone: false,
  styleUrl: './product-details-component.css',
  templateUrl: './product-details-component.html',
})
export class ProductDetailsComponent {
    productName: string = "Laptop";
  productDescription: string = "High-performance laptop";
  productPrice: number = 750;
  productImage: string = "laptop.jpg";
  quantity: number = 1;
  isAvailable: boolean = true;
  discountPercentage: number = 10;
}
