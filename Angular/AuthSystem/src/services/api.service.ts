import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  signup(data: any): Observable<any> {
    return this.http.post('http://localhost:5122/api/user', data);
  }

  Login(data: any): Observable<any> {
    return this.http.post('http://localhost:5122/api/user/login', data);
  }
}
