import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { ItemDetailsComponent } from './item-details-page/item-details.component';
import { ItemPageComponent } from './item-page/item-page.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { BillingInfoComponent } from './billing-info/billing-info.component';
import { DashboardComponent } from './MyAdmin/dashboard/dashboard.component';
import { AddCategoryComponent } from './MyAdmin/add-category/add-category.component';
import { CategoryListComponent } from './MyAdmin/category-list/category-list.component';
import { OrderPageComponent } from './order-page/order-page.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent }, // Route to HomeComponent
  { path: 'itemDetails/:id', component: ItemDetailsComponent },
  { path: 'cart', component: ShoppingCartComponent },
  { path: 'admin/dashboard',component:DashboardComponent },
  { path: 'admin/categoryList',component:CategoryListComponent },
  { path: 'admin/AddCategory/:id',component:AddCategoryComponent },
  { path: 'billingInfo', component: BillingInfoComponent },
  { path: 'myOrders', component: OrderPageComponent },
  { path: 'item', component: ItemPageComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes) // import routes
  ], // Use RouterModule.forRoot for the main module
  exports: [RouterModule],
})
export class AppRoutingModule {}
