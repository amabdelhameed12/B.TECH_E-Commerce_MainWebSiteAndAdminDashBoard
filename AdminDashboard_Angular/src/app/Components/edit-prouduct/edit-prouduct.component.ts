// import { Component, OnInit } from '@angular/core';
// import { Router, ActivatedRoute } from '@angular/router';
// import { Category } from 'src/app/Model/category';
// import { Product } from 'src/app/Model/iproduct';
// import { CategoryService } from 'src/app/Servics/category.service';
// import { ProuductService } from 'src/app/Servics/prouduct.service';



// @Component({
//   selector: 'app-edit-prouduct',
//   templateUrl: './edit-prouduct.component.html',
//   styleUrls: ['./edit-prouduct.component.css']
// })
// export class EditProuductComponent implements OnInit  {

//   categories: Category[] = [];
//   productId: any;
//   product: Product={} as Product;

//   constructor(
//     private productService: ProuductService,
//     private route: ActivatedRoute,
//     private router: Router,
//     private cat:CategoryService
//   ) {}

//   ngOnInit(): void {
//     this.productId = this.route.snapshot.params['id'];
//     this.productService.getProductById(this.productId).subscribe((data) => {
//       this.product = data;
//     });
//     this.cat.getCategories()
//     .subscribe(categories => this.categories = categories);
//   }

//   saveProduct(): void {
//     this.productService.Edit(this.product).subscribe(() => {
//       this.router.navigate(['/Products']);
//     });
//   }

// } 

/////////////////////////////////

import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/Model/category';
import { Product } from 'src/app/Model/iproduct';
import { CategoryService } from 'src/app/Servics/category.service';
import { ProuductService } from 'src/app/Servics/prouduct.service';



@Component({
  selector: 'app-edit-prouduct',
  templateUrl: './edit-prouduct.component.html',
  styleUrls: ['./edit-prouduct.component.css']
})
export class EditProuductComponent implements OnInit  {

  selectedFile: File | null = null;
  imgurls  :string = '';
  categories: Category[] = [];
  productId: any;
  product: Product={} as Product;

  constructor(
    private productService: ProuductService,
    private route: ActivatedRoute,
    private router: Router,
    private cat:CategoryService,
    private http:HttpClient
  ) {}

  onFileSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files.length > 0) {
      this.selectedFile = inputElement.files[0];
      console.log(this.selectedFile);
    }
  }
  

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];
    this.productService.getProductById(this.productId).subscribe((data) => {
      this.product = data;
      this.imgurls = this.product.imageUrl
    });
    this.cat.getCategories()
    .subscribe(categories => this.categories = categories);
  }

  onSubmit() {
      const newProduct: Product = this.product;
      console.log(newProduct);
      
      if (this.selectedFile) {
        this.uploadFile(newProduct);
      } else {
        this.saveProduct(newProduct);
      }
    }
    
    uploadFile(newProduct: Product) {
      if (this.selectedFile) {
        const formData = new FormData();
        formData.append('file', this.selectedFile);
        
        this.http.post<any>('https://localhost:44384/api/Product/UploadFile', formData, {
          reportProgress: true,
          observe: 'events',
      }).subscribe({
        next: (event) => {
          if (event.type === HttpEventType.Response) {
            if (event.body && event.body.message === 'File uploaded successfully') {
              console.log('File uploaded successfully:', event.body.message);
              this.saveProduct(newProduct);
            } else {
              console.log('Unexpected server response:', event.body);
            }
          }
        },
        error: (error) => {
          console.error('Error uploading file:', error);
        }
      });
    }
  }

  saveProduct(newProduct: Product ): void {
    if(this.selectedFile){
      newProduct.imageUrl = 'https://localhost:44384/api/Product/' + this.selectedFile.name;
      console.log(this.product.imageUrl);
      
      console.log(newProduct);
      this.finallyEdit(newProduct)
    } else {
      newProduct.imageUrl = this.imgurls;
      console.log(this.product.imageUrl);
      
      console.log(newProduct);
      this.finallyEdit(newProduct)
    }
    }

    finallyEdit(newProduct: Product) {
      setTimeout(() => {
        this.productService.Edit(newProduct).subscribe(() => {
          this.router.navigate(['/Products']);
        });
      }, 1000);
    }

} 
