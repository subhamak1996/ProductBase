import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetProductDetailsService {
  private apiUrl = 'https://localhost:7153/api/ProductDetails';     
  constructor(private http: HttpClient) { }
  getproductdetails():Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl)
  }
}
