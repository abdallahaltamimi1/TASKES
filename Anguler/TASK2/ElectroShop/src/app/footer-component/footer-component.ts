import { Component } from '@angular/core';

@Component({
  selector: 'app-footer-component',
  standalone: false,
  styleUrl: './footer-component.css',
  templateUrl: './footer-component.html',
})
export class FooterComponent {
   storeName: string = "ElectroShop";
  storeAddress: string = "Irbid, Jordan";
  contactEmail: string = "info@example.com";
  copyrightMessage: string = "© 2026 ElectroShop. All rights reserved.";

}
