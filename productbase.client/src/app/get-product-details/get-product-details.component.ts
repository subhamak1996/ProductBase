import { Component } from '@angular/core';
import { GetProductDetailsService } from '../services/get-product-details.service';

@Component({
  selector: 'getproductdetails',
  templateUrl: './get-product-details.component.html',
  styleUrl: './get-product-details.component.css'
})
export class GetProductDetailsComponent {
  ProductDetails: any[] = [];
  errorMessage: string = '';
  constructor(private GetProductDetailsService: GetProductDetailsService) {

  }
  ngOnInit()
  {
    this.GetProductDetail();
  }
  GetProductDetail(): void {
    this.GetProductDetailsService.getproductdetails().subscribe(
      (data) => this.ProductDetails = data,
      (Error) => {
        console.error('Error Featch Product Details ', Error);
        this.errorMessage = "Could not load product Details. Please try again later.";
      }
    );

  }
}
