// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';

// @Injectable({
//   providedIn: 'root'
// })
// export class AdminSerService {
//   private apiUrl = 'https://localhost:44384/api/Login'; // Replace with your API URL

//   constructor(private http: HttpClient) {}

//   login(username: string, password: string): Observable<boolean> {
//     const loginUrl = `${this.apiUrl}/Found`;
//     const body = { name: username, password: password };

//     return this.http.post<boolean>(loginUrl, body);
//   }
// }



import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminSerService {
  private apiUrl = 'https://localhost:44384/api/Login'; // Replace with your API URL
  private loggedIn = false;

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<boolean> {
    const loginUrl = `${this.apiUrl}/Found`;
    const body = { name: username, password: password };
  
    return this.http.post<boolean>(loginUrl, body).pipe(
      tap(result => {
        if (result) {
          this.loggedIn = true; // Update login status
        }
      })
    );
  }
  logout() {
    this.loggedIn = false; // Implement logout logic
  }

  isLoggedIn(): boolean {
    return this.loggedIn;
  }

  setLoggedIn(value: boolean): void {
    this.loggedIn = value;
  }
}