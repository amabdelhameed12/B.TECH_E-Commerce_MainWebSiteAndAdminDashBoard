import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/Model/category';
import { Product } from 'src/app/Model/iproduct';
import { CategoryService } from 'src/app/Servics/category.service';
import { ProuductService } from 'src/app/Servics/prouduct.service';

@Component({
  selector: 'app-add-proudect',
  templateUrl: './Proudect.component.html',
  styleUrls: ['./Proudect.component.css']
})
export class AddProudectComponent implements OnInit {
  products: Product[] = [];
  count: number = 0;
  categories: Category[] = [];

  constructor(private productService: ProuductService,private router: Router,private categoryService: CategoryService,) {}

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe((data: Product[]) => {
      this.products = data;
      console.log(this.products);
    });
    this.categoryService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
    });
  }
  getCategoryName(categoryId: number): string {
    const category = this.categories.find((c) => c.id === categoryId);
    return category ? category.name : '';
  }
  deleteProduct(productId: number) {
    const ShouldDelete= window.confirm("Are you sure to delete?");
    if(ShouldDelete)
    {
    this.productService.deleteProduct(productId).subscribe(() => {
      this.productService.getAllProducts().subscribe((data) => {
        this.products = data;
      });
    });
  }
  }
  prdDetails(prdId: number) {
    this.router.navigate(['/prd', prdId]);
  }

  editProduct(productId: number) {
    this.router.navigate(['/edit', productId]);
  }
}