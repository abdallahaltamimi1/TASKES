import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { ProductDetailsComponent } from './product-details-component/product-details-component';
import { ShoppingCartComponent } from './shopping-cart-component/shopping-cart-component';

@NgModule({
  declarations: [App, ProductDetailsComponent, ShoppingCartComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [provideBrowserGlobalErrorListeners(), provideClientHydration()],
  bootstrap: [App],
})
export class AppModule {}
