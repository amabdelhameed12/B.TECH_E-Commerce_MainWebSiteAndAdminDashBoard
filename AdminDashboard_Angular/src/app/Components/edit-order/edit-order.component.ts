
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from 'src/app/Model/iorder';
import { OrdersService } from 'src/app/Servics/orders.service';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent implements OnInit {
  order!: Order;
  orderId: any;

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.orderId = +params['id'];
      this.getOrderById(this.orderId);
    });
  }

  getOrderById(id: number): void {
    this.ordersService.getOrderById(id).subscribe((order) => {
      this.order = order;
    });
  }

  saveChanges(): void {
    this.ordersService.updateOrder(this.orderId, this.order).subscribe(() => {
      this.router.navigate(['/order']);
    });
  }

}
