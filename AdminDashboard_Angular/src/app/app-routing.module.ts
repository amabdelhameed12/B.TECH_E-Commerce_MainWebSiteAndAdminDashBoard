import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './Components/main-layout/main-layout.component';
import { AddBrandComponent } from './Components/add-brand/add-brand.component';
import { AddCategoryComponent } from './Components/add-category/add-category.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { LoginComponent } from './Components/login/login.component';
import { AddNewProudutComponent } from './Components/add-new-proudut/add-new-proudut.component';
import { ProuductDetailsComponent } from './Components/prouduct-details/prouduct-details.component';
import { EditProuductComponent } from './Components/edit-prouduct/edit-prouduct.component';
import { AddProudectComponent } from './Components/Prouduct/Proudect.component';
import { UsersComponent } from './Components/users/users.component';
import { OrderComponent } from './Components/order/order.component';
import { CategoryComponent } from './Components/category/category.component';
import { EditCtegoryComponent } from './Components/edit-ctegory/edit-ctegory.component';
import { AuthorizationGuard } from './Guards/authorization.guard';
import { EditOrderComponent } from './Components/edit-order/edit-order.component';

const routes: Routes = [
  {path:'',redirectTo:'login',pathMatch:'full'},
  {path:'login',component: LoginComponent},
  { path: '', component: MainLayoutComponent, canActivate: [AuthorizationGuard], children: [

    {path:'',redirectTo:'Categories',pathMatch:'full'},
    {path:'Categories',component:CategoryComponent},

    
    {path:'addCategories',component:AddCategoryComponent},
    { path: 'edite/:id', component:EditCtegoryComponent },

    {path:'Products',component:AddProudectComponent},
    {path:'Brands',component:AddBrandComponent},
    {path:'AddnewProuduct',component:AddNewProudutComponent},
    {path:'prd/:id',component:ProuductDetailsComponent,title:'Product details page'},
    { path: 'edit/:id', component:EditProuductComponent },
    { path: 'editorder/:id', component:EditOrderComponent },

    {path:'users',component:UsersComponent},
    {path:'order',component:OrderComponent},


    {path:'**',component:CategoryComponent},

  ]},

  //wildcard path 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
