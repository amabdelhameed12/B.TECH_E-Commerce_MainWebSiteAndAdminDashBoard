import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/Model/category';
import { CategoryService } from 'src/app/Servics/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categoryList: Category[]=[];

  constructor(private categoryService: CategoryService,    private router: Router
    ) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.categoryService.getCategories()
      .subscribe(categories => this.categoryList = categories);
  }
  deleteCategory(categoryId: number): void {
    const ShouldDelete= window.confirm("Are you sure to delete?");
    if(ShouldDelete)
    {
    this.categoryService.deleteCategory(categoryId)
      .subscribe(() => {
        this.categoryList = this.categoryList.filter(category => category.id !== categoryId);
      });
    }
  }
  editcategory(categorytId: number) {
    this.router.navigate(['/edite', categorytId]);
  }
}