import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { HeaderComponent } from './header-component/header-component';
import { NavbarComponent } from './navbar-component/navbar-component';
import { ProductListComponent } from './product-list-component/product-list-component';
import { ProductDetailsComponent } from './product-details-component/product-details-component';
import { FooterComponent } from './footer-component/footer-component';

@NgModule({
  declarations: [
    App,
    HeaderComponent,
    NavbarComponent,
    ProductListComponent,
    ProductDetailsComponent,
    FooterComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [provideBrowserGlobalErrorListeners(), provideClientHydration()],
  bootstrap: [App],
})
export class AppModule {}
