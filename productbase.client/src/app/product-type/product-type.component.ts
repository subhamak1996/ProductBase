import { Component } from '@angular/core';
import { ProductTypeService } from '../services/product-type.service';

@Component({
  selector: 'app-product-type',
  templateUrl: './product-type.component.html',
  styleUrl: './product-type.component.css'
})
export class ProductTypeComponent {
  productType = {
    ProductTypeName: '',
    ProductTypeDescription: ''
  };

  constructor(private productTypeService: ProductTypeService) { }

  // Method to handle form submission
  onSubmit() {
    this.productTypeService.insertProductType(this.productType)
      .subscribe(response => {
        console.log('Product type inserted successfully:', response);
        // You can reset the form or provide feedback here
      }, error => {
        console.error('Error inserting product type:', error);
      });
  }
}
