// Sepet varlığını temsil eden sınıf.
import { ProductEntity } from "./product.entity";

export class BasketEntity {
    // Sepetin benzersiz kimliğini temsil eden özellik.
    id: string = "";

    // Sepetteki ürünün benzersiz kimliğini temsil eden özellik.
    productId: string = "";

    // Sepetteki ürünü temsil eden özellik.
    product: ProductEntity = new ProductEntity();

    // Sepetteki ürünün miktarını temsil eden özellik.
    quantity: number = 0;
}
