import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../Model/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = 'https://localhost:44384/api/Category';
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2OTA4MjQ0NzgsImV4cCI6MTY5MjU1MjQ3OCwiaWF0IjoxNjkwODI0NDc4fQ.rhGFg13iPxpzgStZmAuzg8z8uoC9SMbMq6qLU_k2vPM'; // استبدلها بقيمة الـ Bearer token الخاص بك

  constructor(private httpClient: HttpClient) {}

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}` // إضافة الـ Bearer token هنا
    });
  }

  addCategory(category: Category): Observable<Category> {
    return this.httpClient.post<Category>(
      `${this.apiUrl}/AddCategory`,
      category,
      { headers: this.getHeaders() }
    );
  }

  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(
      `${this.apiUrl}/GetAllCategory`,
      { headers: this.getHeaders() }
    );
  }

  deleteCategory(id: number): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/DeleteCategory?id=${id}`, {
      headers: this.getHeaders()
    });
  }

  updateCategory(id: number, category: Category): Observable<any> {
    return this.httpClient.put(
      `${this.apiUrl}/updatecategory?id=${id}`,
      category,
      { headers: this.getHeaders() }
    );
  }

  getcatdByID(id: number): Observable<Category> {
    return this.httpClient.get<Category>(
      `${this.apiUrl}/GetCategorybyid?id=${id}`,
      { headers: this.getHeaders() }
    );
  }
}