
// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { Router } from '@angular/router';
// import { ProuductService } from 'src/app/Servics/prouduct.service';
// import { Product } from 'src/app/Model/iproduct';
// import { CategoryService } from 'src/app/Servics/category.service';
// import { Category } from 'src/app/Model/category';
// import { HttpClient, HttpEventType } from '@angular/common/http';

// @Component({
//   selector: 'app-add-new-proudut',
//   templateUrl: './add-new-proudut.component.html',
//   styleUrls: ['./add-new-proudut.component.css']
// })
// export class AddNewProudutComponent implements OnInit {

//   selectedFile: File | null = null;
//   productForm!: FormGroup;
//   categories: Category[] = [];

//   constructor(
//     private formBuilder: FormBuilder,
//     private router: Router,
//     private productService: ProuductService,
//     private cat: CategoryService,
//     private http: HttpClient
//   ) { }

//   ngOnInit() {
//     this.productForm = this.formBuilder.group({
//       name: ['', Validators.required],
//       description: ['', Validators.required],
//       price: ['', Validators.required],
//       quantity: ['', Validators.required],
//       imageUrl: [''],
//       categoryId: ['', Validators.required],
//       discount: ['']
//     });

//     this.cat.getCategories()
//       .subscribe(categories => this.categories = categories);
//   }

//   onFileSelected(event: Event) {
//     const inputElement = event.target as HTMLInputElement;
//     if (inputElement.files && inputElement.files.length > 0) {
//       this.selectedFile = inputElement.files[0];
//       console.log(this.selectedFile);
//     }
//   }

//   onSubmit() {
//     if (this.productForm.valid) {
//       const newProduct: Product = this.productForm.value;

//       this.productService.addProduct(newProduct).subscribe({
//         next: (response) => {
//           console.log('Product added successfully', response);

//           if (this.selectedFile) {
//             this.uploadFile();
//           } else {
//             console.log('Product added without image');
//             this.router.navigate(['/Products']);
//           }
//         },
//         error: (error) => {
//           console.error('Error adding product', error);
//         }
//       });
//     }
//   }
  
//   uploadFile() {
//     if (this.selectedFile) {
//       const formData = new FormData();
//       formData.append('file', this.selectedFile);
  
//       this.http.post<any>('https://localhost:44384/api/Product/UploadFile', formData, {
//         reportProgress: true,
//         observe: 'events',
//       }).subscribe(event => {
//         if (event.type === HttpEventType.UploadProgress) {
//           if (event.total) {
//             const percentDone = Math.round((100 * event.loaded) / event.total);
//             console.log(`Upload progress: ${percentDone}%`);
//           }
//         } else if (event.type === HttpEventType.Response) {
//           console.log('File uploaded successfully:', event.body);
//         }
//       });
//     }
//   }
// }


/////////////////////////////////////////////////
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProuductService } from 'src/app/Servics/prouduct.service';
import { Product } from 'src/app/Model/iproduct';
import { CategoryService } from 'src/app/Servics/category.service';
import { Category } from 'src/app/Model/category';
import { HttpClient, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-add-new-proudut',
  templateUrl: './add-new-proudut.component.html',
  styleUrls: ['./add-new-proudut.component.css']
})
export class AddNewProudutComponent implements OnInit {

  selectedFile: File | null = null;
  productForm!: FormGroup;
  categories: Category[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private productService: ProuductService,
    private cat: CategoryService,
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      quantity: ['', Validators.required],
      imageUrl: [''],
      categoryId: ['', Validators.required],
      discount: ['']
    });

    this.cat.getCategories()
      .subscribe(categories => this.categories = categories);
  }

  onFileSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files.length > 0) {
      this.selectedFile = inputElement.files[0];
      console.log(this.selectedFile);
    }
  }

  onSubmit() {
    if (this.productForm.valid) {
      const newProduct: Product = this.productForm.value;

      if (this.selectedFile) {
        this.uploadFile(newProduct);
      } else {
        this.addProduct(newProduct);
      }
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
              this.addProductWithImage(newProduct);
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

  addProduct(newProduct: Product) {
    this.productService.addProduct(newProduct).subscribe({
      next: (response) => {
        console.log('Product added successfully', response);
        this.router.navigate(['/Products']);
      },
      error: (error) => {
        console.error('Error adding product', error);
      }
    });
  }

  addProductWithImage(newProduct: Product) {
    newProduct.imageUrl = 'https://localhost:44384/api/Product/' + this.selectedFile!.name;

    this.addProduct(newProduct);
  }
}
