import { Component } from '@angular/core';
import { ProductDetailsService } from '../services/product-details.service';
import { GetProductTypeService } from '../services/get-product-type.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {
  productTypes: any[] = [];  // Array to store product types
  errorMessage: string = '';
  Product = {
    PTId: '',
    ProductNameName: '',
    ProductDescription: ''
  }
  showAlert: boolean = false;  
  alertMessage: string = '';  
  constructor(private ProductDetailsService: ProductDetailsService, private GetproductTypeService: GetProductTypeService) {

  }
  
  ngOnInit() {
   this.loadProductTypes();
  }
  loadProductTypes(): void {
    this.GetproductTypeService.getProductTypes()
      .subscribe(
        (data) => { this.productTypes = data; },
        (error) => {
          console.error('Error fetching product types:', error);
          this.errorMessage = 'Could not load product types. Please try again later.';
        }
      );
  }
 
  onSubmit() {
    //this.Product.pdId = this.generateGuid();
    this.ProductDetailsService.InsertproductDetails(this.Product).subscribe(response => {
      console.log("Product Details inserted successfully ", response)
      this.showAlert = true;
      this.alertMessage = 'Product added successfully!';
      this.Product.ProductDescription = "";
      this.Product.ProductNameName = "";
      this.Product.PTId = "";
    }, (error) => {
      console.error('Error inserting product type:', error);
    });
  }
  generateGuid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
      const r = (Math.random() * 16) | 0;
      const v = c === 'x' ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }
}
