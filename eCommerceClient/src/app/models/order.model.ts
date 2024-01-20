import { ProductModel } from "./product.model";

export class OrderModel{
    id: number = 0;
    userId: number = 0;
    productId: number = 0;
    product: ProductModel = new ProductModel();
    quantity: number = 0;
}