import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  signup(data: any): Observable<any> {
    return this.http.post('http://localhost:5122/api/user', data);
  }

  Login(data: any): Observable<any> {
    return this.http.post('http://localhost:5122/api/user/login', data).pipe(
      map((response: any) => {
        if (response?.data) {
          console.log('Token received:', response.data);
          localStorage.setItem('token', response.data);
        } else {
          console.warn('No token found in response:', response);
        }
        return response;
      })
    );
  }

  getUserDetails(): Observable<any> {
    return this.http.get('http://localhost:5122/api/user/profile');
  }
}