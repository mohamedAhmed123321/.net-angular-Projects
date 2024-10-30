import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ItemDetailsComponent } from './item-details-page/item-details.component';
import { ItemPageComponent } from './item-page/item-page.component'
import { provideHttpClient, withInterceptorsFromDi ,withFetch } from '@angular/common/http';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { FormsModule } from '@angular/forms';
import { BillingInfoComponent } from './billing-info/billing-info.component';
import { AdminFooterComponent } from './MyAdmin/admin-footer/admin-footer.component';
import { DashboardComponent } from './MyAdmin/dashboard/dashboard.component';
import { AdminHeaderComponent } from './MyAdmin/admin-header/admin-header.component';
import { AddCategoryComponent } from './MyAdmin/add-category/add-category.component';
import { CategoryListComponent } from './MyAdmin/category-list/category-list.component';
import { OrderPageComponent } from './order-page/order-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    HeaderComponent,
    FooterComponent,
    ItemDetailsComponent,
    ItemPageComponent,
    ShoppingCartComponent,
    BillingInfoComponent,
    AdminFooterComponent,
    DashboardComponent,
    AdminHeaderComponent,
    AddCategoryComponent,
    CategoryListComponent,
    OrderPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,

],
  providers: [
    provideClientHydration(),
    provideHttpClient(withInterceptorsFromDi(),withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
