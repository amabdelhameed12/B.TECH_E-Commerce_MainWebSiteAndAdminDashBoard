import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from 'src/app/Model/iorder';
import { OrdersService } from 'src/app/Servics/orders.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  orders: Order[] = [];
  TotalProfits: number = 0;

  constructor(private ordersService: OrdersService,private router: Router) {}

  ngOnInit(): void {
    this.getOrders();
  }

  
  getOrders(): void {
    this.ordersService.getOrders().subscribe((orders) => {
      this.orders = orders;
      this.calculateTotalProfits(this.orders);
    });
  }

  calculateTotalProfits(orders: Order[]): void {
    this.TotalProfits = orders
      .filter(order => order.status === 'Delivered') // Filter orders with status 'delivered'
      .reduce((total, order) => total + order.total, 0);
    console.log(this.TotalProfits);
  }

  editorder(ordertId: number) {
    this.router.navigate(['/editorder', ordertId]);
  }
}