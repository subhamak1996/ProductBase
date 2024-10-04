import { Component } from '@angular/core';
import { GetProductTypeService } from '../services/get-product-type.service';

@Component({
  selector: 'app-get-product-type',
  templateUrl: './get-product-type.component.html',
  styleUrl: './get-product-type.component.css'
})
export class GetProductTypeComponent {
  productTypes: any[] = [];  // Array to store product types
  errorMessage: string = '';

  constructor(private GetproductTypeService: GetProductTypeService) { }

  ngOnInit() {
    this.loadProductTypes();
  }

  // Method to load product types from API
  loadProductTypes(): void {
    this.GetproductTypeService.getProductTypes()
      .subscribe(
        (data) => {this.productTypes = data;},
        (error) => {
          console.error('Error fetching product types:', error);
          this.errorMessage = 'Could not load product types. Please try again later.';
        }
      );
  }
}
