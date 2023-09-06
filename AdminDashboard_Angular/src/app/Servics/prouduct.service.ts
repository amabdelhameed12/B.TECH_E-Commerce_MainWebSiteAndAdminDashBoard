
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../Model/iproduct';
import { Category } from '../Model/category';

@Injectable({
  providedIn: 'root'
})
export class ProuductService {
  private apiUrl = 'https://localhost:44384/api/Product';
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2OTA4MjQ0NzgsImV4cCI6MTY5MjU1MjQ3OCwiaWF0IjoxNjkwODI0NDc4fQ.rhGFg13iPxpzgStZmAuzg8z8uoC9SMbMq6qLU_k2vPM'; // استبدلها بقيمة الـ Bearer token الخاص بك

  constructor(private httpClient: HttpClient) {}

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}` // إضافة الـ Bearer token هنا
    });
  }

  getAllProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`${this.apiUrl}/GetAllProduct`, {
      headers: this.getHeaders()
    });
  }

  getProductById(id: number): Observable<Product> {
    return this.httpClient.get<Product>(`${this.apiUrl}/GetProductbyid?id=${id}`, {
      headers: this.getHeaders()
    });
  }

  addProduct(product: Product): Observable<any> {
    return this.httpClient.post<any>(`${this.apiUrl}/Addproduct`, product, {
      headers: this.getHeaders()
    });
  }

  deleteProduct(id: number): Observable<any> {
    return this.httpClient.delete<any>(`${this.apiUrl}/DeleteProduct?id=${id}`, {
      headers: this.getHeaders()
    });
  }

  Edit(product: Product): Observable<Product> {
    return this.httpClient.put<Product>(`${this.apiUrl}/updateProduct?id=${product.id}`,(product),{
      headers: this.getHeaders()
  });
  }


}


