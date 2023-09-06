

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from '../Model/iorder';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private apiUrl = 'https://localhost:44384/api/Order';
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2OTA4MjQ0NzgsImV4cCI6MTY5MjU1MjQ3OCwiaWF0IjoxNjkwODI0NDc4fQ.rhGFg13iPxpzgStZmAuzg8z8uoC9SMbMq6qLU_k2vPM'; // استبدلها بقيمة الـ Bearer token الخاص بك

  constructor(private httpClient: HttpClient) {}

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}` // إضافة الـ Bearer token هنا
    });
  }

  addOrder(order: Order): Observable<Order> {
    return this.httpClient.post<Order>(
      `${this.apiUrl}/AddOrder`,
      order,
      { headers: this.getHeaders() }
    );
  }

  getOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(
      `${this.apiUrl}/GetAllOrder`,
      { headers: this.getHeaders() }
    );
  }

  deleteOrder(id: number): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/DeleteOrder?ordernumber=${id}`, {
      headers: this.getHeaders()
    });
  }


  updateOrder(id: number, order: Order): Observable<any> {
    return this.httpClient.put(
      `${this.apiUrl}/updateOrder?ordernumber=${id}`,
      order,
      { headers: this.getHeaders() }
    );
  }

  getOrderById(id: number): Observable<Order> {
    return this.httpClient.get<Order>(
      `${this.apiUrl}/GetOrderbyid?ordernumber=${id}`,
      { headers: this.getHeaders() }
    );
  }
}