import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Model/category';
import { CategoryService } from 'src/app/Servics/category.service';

@Component({
  selector: 'app-edit-ctegory',
  templateUrl: './edit-ctegory.component.html',
  styleUrls: ['./edit-ctegory.component.css']
})
export class EditCtegoryComponent implements OnInit {

  category!: Category;

  constructor(
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private router: Router  ) { }

  ngOnInit(): void {
    this.getCategory();
  }

  getCategory(): void {
    const categoryId = +this.route.snapshot.paramMap.get('id')!;
    this.categoryService.getcatdByID(categoryId)
      .subscribe(category => this.category = category);
  }

  saveCategory(): void {
    this.categoryService.updateCategory(this.category.id, this.category)
      .subscribe(() => {
        const link = ['/categories'];
        this.router.navigate(link);
      });
  }
}
