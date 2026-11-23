import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: false,
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('ElectroShop');
  storeName:string="ElectroShop";
  storeDescription:string="Your favorite electronics store"
  storeAddress:string="Amman, Jordan"
  totalProducts:number=12;
  isStoreOpen: boolean = true;
  currency:string="JOD"
  message:string=""
 productNames: string[] = ["Laptop","Phone","Tablet","Keyboard"];
 productPrices: number[] = [1000, 500, 300, 50];
 featuredProduct = [
  { name: "Laptop", price: 750, description: "Laptop" },
  { name: "Smartphone", price: 450, description: "Smartphone" },
  { name: "Headphones", price: 80, description: "Headphones" },
  { name: "Smart Watch", price: 120, description: "Smart Watch" },
  { name: "Keyboard", price: 45, description: "Keyboard" }
];
discountPercentage:number=10;
Finalprice:number=0;
totalNumberOfProducts: number = 0;
  mostExpensiveProductPrice: number = 0;
  cheapestProductPrice: number = 0;
  totalValue: number = 0;
 constructor() {

  
  if (this.isStoreOpen) {
    this.message = "We Are Open";
  } else {
    this.message = "We Are Closed";
  }


  this.Finalprice = this.featuredProduct[0].price -
    (this.featuredProduct[0].price *
      this.discountPercentage / 100);

 
  this.totalNumberOfProducts = 0;
  this.mostExpensiveProductPrice = this.featuredProduct[0].price;
  this.cheapestProductPrice = this.featuredProduct[0].price;
  this.totalValue = 0;

  for (let i = 0; i < this.featuredProduct.length; i++) {

    this.totalNumberOfProducts++;

    this.totalValue += this.featuredProduct[i].price;

    if (this.featuredProduct[i].price > this.mostExpensiveProductPrice) {
      this.mostExpensiveProductPrice = this.featuredProduct[i].price;
    }

    if (this.featuredProduct[i].price < this.cheapestProductPrice) {
      this.cheapestProductPrice = this.featuredProduct[i].price;
    }
  }
}
}
