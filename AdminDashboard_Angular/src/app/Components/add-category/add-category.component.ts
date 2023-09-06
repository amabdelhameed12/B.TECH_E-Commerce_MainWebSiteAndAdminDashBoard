import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Category } from 'src/app/Model/category';
import { CategoryService } from 'src/app/Servics/category.service';
import { ProuductService } from 'src/app/Servics/prouduct.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
 categoryName: string ;


  constructor(private categoryService: CategoryService) {
   this.categoryName='';
   }

   addCategory() {
    const category: Category = {id:0 , name: this.categoryName };
    this.categoryService.addCategory(category).subscribe(
      (category: Category) => console.log(`Added category with ID ${category.id}`),
    );
    this.categoryName = '';
  }

}
