import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductTypeService {
  private apiUrl = 'https://localhost:7153/api/ProductTypes'; 
  constructor(private http: HttpClient) { }

  // Method to insert new product type
  insertProductType(productType: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post(this.apiUrl, productType, { headers });
  }
}
