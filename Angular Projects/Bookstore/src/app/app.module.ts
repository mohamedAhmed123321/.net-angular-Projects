import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from "@angular/forms"
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import {BillingInfoComponent  } from './components/billing-info/billing-info.component';
import { BookDetailsComponent } from './components/book-details-page/book-details.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { OrderPageComponent } from './components/order-page/order-page.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { AddBookComponent } from './admin/add-book/add-book.component';
import { AminBookListComponent } from './admin/admin-book-list/admin-book-list.component';
import { AdminHeaderComponent } from './admin/admin-header/admin-header.component';
import { AdminFooterComponent } from './admin/admin-footer/admin-footer.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    BookListComponent,
    HomePageComponent,
    BillingInfoComponent,
    BookDetailsComponent,
    FooterComponent,
    HeaderComponent,
    OrderPageComponent,
    ShoppingCartComponent,
    DashboardComponent,
    AddBookComponent,
    AdminHeaderComponent,
    AdminFooterComponent,
    AminBookListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
