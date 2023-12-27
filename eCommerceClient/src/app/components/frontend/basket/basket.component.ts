import { Component } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BasketEntity } from '../../../entities/basket.entity';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-basket',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [TrCurrencyPipe],

  // Bileşenin kullanacağı HTML şablonunu belirler.
  templateUrl: './basket.component.html',

  // Bileşenin kullanacağı CSS dosyasının yolunu belirler.
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  // Sepetteki ürünleri tutan dizi.
  carts: BasketEntity[] = [];

  // Sepet toplamını tutan değişken.
  sum: number = 0;

  // Bileşenin yapıcı metodu.
  constructor(private http: HttpClient){}

  // Angular yaşam döngüsü olaylarından biri olan ngOnInit metodu.
  // Bileşen ilk kez yüklendiğinde çağrılır.
  ngOnInit(): void{
    // Tüm ürünleri almak için HTTP isteği yapar.
    this.getAll();
  }

  // Tüm ürünleri almak için HTTP isteği yapar.
  getAll() {
    this.http.get("assets/db.json")
      .subscribe({
        next: (res: any) => {
          // HTTP yanıtındaki sepet verilerini alır.
          this.carts = res.carts;

          // Toplam tutarı hesaplar.
          this.calculateSum();
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      });
  }

  // Ürün miktarını artırmak için kullanılan metod.
  increment(cart: BasketEntity) {
    cart.quantity++;

    // Toplam tutarı günceller.
    this.calculateSum();
  }

  // Ürün miktarını azaltmak için kullanılan metod.
  decrement(cart: BasketEntity) {
    if (cart.quantity === 1) {
      // Eğer ürün miktarı 1 ise kullanıcıya onay sorar.
      const response = confirm("Ürünü sepetten kaldırmak istiyor musunuz?");
      if (response) {
        // Kullanıcı onaylarsa, ürünü sepetten kaldırır.
        const index = this.carts.findIndex(p => p === cart);
        this.carts.splice(index, 1);

        // Toplam tutarı günceller.
        this.calculateSum();
      }
      return;
    }
    // Ürün miktarını azaltır.
    cart.quantity--;

    // Toplam tutarı günceller.
    this.calculateSum();
  }

  // Ürünü sepetten kaldırmak için kullanılan metod.
  remove(index: number) {
    // Kullanıcıya onay sorar.
    const response = confirm("Ürünü sepetten kaldırmak istiyor musunuz?");
    if (response) {
      // Kullanıcı onaylarsa, ürünü sepetten kaldırır.
      this.carts.splice(index, 1);

      // Toplam tutarı günceller.
      this.calculateSum();
    }
  }

  // Toplam tutarı hesaplamak için kullanılan metod.
  calculateSum(){
    this.sum = 0;
    for(const cart of this.carts){
        this.sum += cart.quantity * cart.product.price;
    }
  }
}
