import { Component ,signal} from '@angular/core';
import { Input } from '@angular/core';

@Component({
  selector: 'app-shopping-cart-component',
  standalone: false,
  styleUrl: './shopping-cart-component.css',
  templateUrl: './shopping-cart-component.html',
})
export class ShoppingCartComponent {
 @Input() cartProduct: string = "";
@Input() cartQuantity: number = 0;
  @Input() cartPrice: number = 0;
  

}

