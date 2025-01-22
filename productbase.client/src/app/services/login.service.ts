import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = 'https://localhost:7153/api/Login';
  private tokenKey = 'authToken';
  constructor(private http: HttpClient) { }
  Login(LoginDetail: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, LoginDetail).pipe(tap((response: any) => {
      localStorage.setItem(this.tokenKey, response.result);
    }));
  }
}
