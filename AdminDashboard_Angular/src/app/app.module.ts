import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './Components/main-layout/main-layout.component';
import { LoginComponent } from './Components/login/login.component';
import { AddCategoryComponent } from './Components/add-category/add-category.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { AddProudectComponent } from './Components/Prouduct/Proudect.component';
import { AddBrandComponent } from './Components/add-brand/add-brand.component';
import { SideMenuComponent } from './Components/side-menu/side-menu.component';
import { HeaderComponent } from './Components/header/header.component';
import { AddNewProudutComponent } from './Components/add-new-proudut/add-new-proudut.component';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ProuductDetailsComponent } from './Components/prouduct-details/prouduct-details.component';
import { EditProuductComponent } from './Components/edit-prouduct/edit-prouduct.component';
import { UsersComponent } from './Components/users/users.component';
import { OrderComponent } from './Components/order/order.component';
import { CategoryComponent } from './Components/category/category.component';

import { EditCtegoryComponent } from './Components/edit-ctegory/edit-ctegory.component';
import { EditOrderComponent } from './Components/edit-order/edit-order.component';


@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    LoginComponent,
    AddCategoryComponent,
    NotFoundComponent,
    AddProudectComponent,
    AddBrandComponent,
    SideMenuComponent,
    HeaderComponent,
    AddNewProudutComponent,
    ProuductDetailsComponent,
    EditProuductComponent,
    UsersComponent,
    OrderComponent,
    CategoryComponent,
    EditCtegoryComponent,
    EditOrderComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule ,
    HttpClientModule,
    ReactiveFormsModule 
  ],
  providers: [    Location 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
