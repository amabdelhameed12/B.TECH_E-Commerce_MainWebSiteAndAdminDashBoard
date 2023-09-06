import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Product } from 'src/app/Model/iproduct';
import { ProuductService } from 'src/app/Servics/prouduct.service';

@Component({
  selector: 'app-prouduct-details',
  templateUrl: './prouduct-details.component.html',
  styleUrls: ['./prouduct-details.component.css']
})
export class ProuductDetailsComponent implements OnInit {

  prdId: number = 0;
  // product:Iproduct ={} as Iproduct;
  product: Product | undefined = undefined;

  // Day5

  // ###########################
  // inject service
  constructor(
    private activatedRoute: ActivatedRoute,
    private prdApiService:ProuductService
  ) {}
  ngOnInit(): void {

    this.prdId = this.activatedRoute.snapshot.paramMap.get('id')
      ? Number(this.activatedRoute.snapshot.paramMap.get('id'))
      : 0;
      this.prdApiService.getProductById(this.prdId).subscribe(data=>{
        this.product=data;
       console.log( this.product);
  
      })
  
    }
}
