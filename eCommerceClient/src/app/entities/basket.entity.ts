// Sepet varlığını temsil eden sınıf.
import { ProductEntity } from "./product.entity";

export class BasketEntity {
    // Sepetin benzersiz kimliğini temsil eden özellik.
    id: number = 0;

    // Sepetteki ürünün benzersiz kimliğini temsil eden özellik.
    productId: number = 0;

    // Sepetteki ürünü temsil eden özellik.
    product: ProductEntity = new ProductEntity();

    // Sepetteki ürünün miktarını temsil eden özellik.
    quantity: number = 0;
}
