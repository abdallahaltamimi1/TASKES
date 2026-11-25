import { Component,signal } from '@angular/core';
import { Input } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-details-component',
  standalone: false,
  styleUrl: './product-details-component.css',
  templateUrl: './product-details-component.html',
})
export class ProductDetailsComponent {
  
  Quantity=signal(5);
  message:string="";

   @Input() productName: string = "";

  @Input() productDescription: string = "";

  @Input() productPrice: number = 0;

  @Input() productAvailability: boolean = false;
  
  @Output() selectedproduct=new EventEmitter<string>();
  @Output() selectedquantity =new EventEmitter<number>();

  
   AddQuantity(){
      this.Quantity.update(q => q + 1);
    }
SubQuantity(){
  if(this.Quantity()>1)
          this.Quantity.update(q => q - 1);
        else
          this.message="Quantity cant be Zero"
    }
AddCart(){
  this.selectedproduct.emit(this.productName);
  this.selectedquantity.emit(this.Quantity())
}
  }

