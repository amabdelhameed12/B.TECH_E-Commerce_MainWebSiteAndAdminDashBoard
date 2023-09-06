import { Category } from "./category";

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  quantity: number;
  imageUrl: string;
  discount:number;
  categoryId: number;

  category?: Category;
}

