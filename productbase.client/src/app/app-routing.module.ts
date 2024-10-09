//import { NgModule } from '@angular/core';
//import { RouterModule, Routes } from '@angular/router';

//const routes: Routes = [];

//@NgModule({
//  imports: [RouterModule.forRoot(routes)],
//  exports: [RouterModule]
//})
//export class AppRoutingModule { }
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegDetailsComponent } from './reg-details/reg-details.component'
import { AppComponent } from './app.component';
import { ProductTypeComponent } from './product-type/product-type.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes: Routes = [
  { path: 'RegDetails', component: RegDetailsComponent },
  { path: 'ProductType', component: ProductTypeComponent },
  { path: 'ProductDetails', component: ProductDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
