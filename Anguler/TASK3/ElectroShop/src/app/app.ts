import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: false,
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  productName = signal("Laptop");

productDescription = signal("Dell Laptop, Core i7, 16GB RAM");

productPrice = signal(850);

productAvailability = signal(true);
ChangeProduct() {
  this.productName.set("Wireless Headphones");
  this.productDescription.set("Bluetooth Headphones");
  this.productPrice.set(120);
  this.productAvailability.set(true);

  this.recieveProduct = "";
  this.recieveQuantity = 0;
}

recieveProduct:string="";
recieveQuantity:number=0;
RecieveProduct(name:string){
  this.recieveProduct=name;
}
RecieveQuantity(quantity:number){
  this.recieveQuantity=quantity;
}

  protected readonly title = signal('ElectroShop');
}
