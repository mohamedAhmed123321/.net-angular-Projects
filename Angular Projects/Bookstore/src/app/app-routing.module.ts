import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { BookListComponent } from './components/book-list/book-list.component'; // Example for book list
import { HomePageComponent } from './components/home-page/home-page.component';
import { BookDetailsComponent } from './components/book-details-page/book-details.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { BillingInfoComponent } from './components/billing-info/billing-info.component';
import { OrderPageComponent } from './components/order-page/order-page.component';
import { AuthGuard } from './guards/auth.guard';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { AminBookListComponent } from './admin/admin-book-list/admin-book-list.component';
import { AddBookComponent } from './admin/add-book/add-book.component';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'books', component: BookListComponent , canActivate: [AuthGuard] },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomePageComponent , canActivate: [AuthGuard] }, // Route to HomeComponent
  { path: 'bookDetails/:id', component: BookDetailsComponent , canActivate: [AuthGuard] },
  { path: 'cart', component: ShoppingCartComponent , canActivate: [AuthGuard] },
   { path: 'admin/dashboard',component:DashboardComponent , canActivate: [AuthGuard] },
  { path: 'admin/books',component:AminBookListComponent , canActivate: [AuthGuard] },
 { path: 'admin/addBook/:id',component:AddBookComponent , canActivate: [AuthGuard] },
  { path: 'billingInfo', component: BillingInfoComponent , canActivate: [AuthGuard] },
  { path: 'myOrders', component: OrderPageComponent , canActivate: [AuthGuard] },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
