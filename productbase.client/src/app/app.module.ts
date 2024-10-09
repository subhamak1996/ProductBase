import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegDetailsComponent } from './reg-details/reg-details.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ProductTypeComponent } from './product-type/product-type.component';
import { GetProductTypeComponent } from './get-product-type/get-product-type.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { InputCompComponent } from './input-comp/input-comp.component';
import { OutputCompComponent } from './output-comp/output-comp.component';
import { GetProductDetailsComponent } from './get-product-details/get-product-details.component';

@NgModule({
  declarations: [
    AppComponent,
    RegDetailsComponent,
    ProductTypeComponent,
    GetProductTypeComponent,
    ProductDetailsComponent,
    InputCompComponent,
    OutputCompComponent,
    GetProductDetailsComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
    , FormsModule, ReactiveFormsModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
