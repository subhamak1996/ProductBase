import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailsService {
  private apiUrl = 'https://localhost:7153/api/ProductDetails';                   
  constructor(private http: HttpClient) { }
  InsertproductDetails(product: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post(this.apiUrl, product, { headers });
  }
}
