/*import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Iusers } from '../Model/iusers';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  httpHeader = {};
  private http={};

  private readonly apiUrl = `${environment.BaseApiUrl}/users`;

  constructor(private httpclient : HttpClient) {
    this.httpHeader = {
      headers: new HttpHeaders({
        'content-type':'application/json',
      })
    };
   }

   
  getUsers(): Observable<Iusers[]> {
    return this.httpclient.get<Iusers[]>(`${this.apiUrl}`);
  }
}*/

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Users } from '../Model/Users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private apiUrl = 'https://localhost:44384/api/Users';
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2OTA4MjQ0NzgsImV4cCI6MTY5MjU1MjQ3OCwiaWF0IjoxNjkwODI0NDc4fQ.rhGFg13iPxpzgStZmAuzg8z8uoC9SMbMq6qLU_k2vPM'; // استبدلها بقيمة الـ Bearer token الخاص بك

  constructor(private httpClient: HttpClient) {}

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}` // إضافة الـ Bearer token هنا
    });
  }

  GetAllUsers(): Observable<Users[]> {
    return this.httpClient.get<Users[]>(
      `${this.apiUrl}/GetAllUsers`,
      { headers: this.getHeaders() }
    );
  }
}
