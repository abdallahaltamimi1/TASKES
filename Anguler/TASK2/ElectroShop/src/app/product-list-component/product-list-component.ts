import { Component } from '@angular/core';

@Component({
  selector: 'app-product-list-component',
  standalone: false,
  styleUrl: './product-list-component.css',
  templateUrl: './product-list-component.html',
})
export class ProductListComponent {
 products = [
  {
    productName: "Laptop",
    description: "High-performance laptop",
    price: 750,
    image: "laptop.jpg",
    isAvailable: true
  },
  {
    productName: "Smartphone",
    description: "Latest smartphone",
    price: 450,
    image: "smartphone.jpg",
    isAvailable: true
  },
  {
    productName: "Headphones",
    description: "Wireless headphones",
    price: 80,
    image: "headphones.jpg",
    isAvailable: true
  },
  {
    productName: "Smart Watch",
    description: "Smart fitness watch",
    price: 120,
    image: "smartwatch.jpg",
    isAvailable: true
  },
  {
    productName: "Keyboard",
    description: "Mechanical keyboard",
    price: 45,
    image: "keyboard.jpg",
    isAvailable: false
  }
];
}
