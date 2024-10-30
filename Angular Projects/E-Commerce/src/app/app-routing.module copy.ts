import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { ItemDetailsComponent } from './item-details-page/item-details.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent }, // Route to HomeComponent
  { path: 'itemDetails/:id', component: ItemDetailsComponent }, // Route to HomeComponent
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // Use RouterModule.forRoot for the main module
  exports: [RouterModule],
})
export class AppRoutingModule {}
