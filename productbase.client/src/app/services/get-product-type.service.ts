import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetProductTypeService {

  private apiUrl = 'https://localhost:7153/api/ProductTypes';

  constructor(private http: HttpClient) { }

  // Method to fetch product types from API
  getProductTypes(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
