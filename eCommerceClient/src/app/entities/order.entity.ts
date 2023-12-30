import { ProductEntity } from "./product.entity";

export class OrderEntity{
    // Siparişin benzersiz kimliğini temsil eden özellik.
    id: string = "";

    // Sipariş'teki ürünün benzersiz kimliğini temsil eden özellik.
    productId: string = "";

    // Sipariş'e ait ürünü temsil eden özellik.
    product: ProductEntity = new ProductEntity();

    // Sipariş edilen ürünün miktarını temsil eden özellik.
    quantity: number = 0;
}