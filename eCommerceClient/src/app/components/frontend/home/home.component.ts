import { Component } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { ProductEntity } from '../../../entities/product.entity';
import { AuthService } from '../../../services/auth.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BasketService } from '../../../services/basket.service';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-home',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [TrCurrencyPipe],

  // Bileşenin kullanacağı HTML şablonunu belirler.
  templateUrl: './home.component.html',

  // Bileşenin kullanacağı CSS dosyasının yolunu belirler.
  styleUrl: './home.component.css'
})
export class HomeComponent {
  apiUrl: string = "https://localhost:7031/api/Products/";
  // Ürünlerin listesini tutan dizi.
  products: ProductEntity[] = [];

  // Kullanıcının kimlik doğrulama durumunu tutan değişken.
  isAuthenticated: boolean = false;

  // Bileşenin yapıcı metodu.
  constructor(
    // AuthService servisine bağımlılığı enjekte eder.
    private auth: AuthService,

    // HttpClient servisine bağımlılığı enjekte eder.
    private http: HttpClient,

    // BasketService servisine bağımlılığı enjekte eder.
    private cart: BasketService
  ) {
    // Sayfa yüklendiğinde kimlik doğrulama durumunu kontrol eder ve ürünleri alır.
    this.isAuthenticated = this.auth.isAuthenticated();
    this.getAllProduct();
  }

  // Tüm ürünleri almak için HTTP isteği yapar.
  getAllProduct() {
    this.http.get(this.apiUrl + "GetAll/", {
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    }).subscribe({
      next: (res: any) => {
        this.products = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    });
  }

  // Sepete ürün eklemek için HTTP isteği yapar.
  addToBasket(productId: number) {
    this.http.get("https://jsonplaceholder.typicode.com/todos").subscribe({
      next: (res: any) => {
        this.cart.count++;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    });
  }

  // Aşağı düğmesini göstermek için kullanılan metod.
  showDownButton(event: any) {
    console.log(event);
    const id = event.target.id;

    event.target.classList.add("d-none");
    const el: any = document.querySelector("#" + id + "+ div");
    el.className = "d-flex mt-2";
  }

  // Orijinal düğmeyi göstermek için kullanılan metod.
  showOriginalButton(event: any) {
    const divId: string = event.target.id;
    const buttonId = divId.replace("div-", "btn-");

    const buttonEl = document.getElementById(buttonId);
    buttonEl?.classList.remove("d-none");

    const el: any = document.querySelector("#" + buttonId + "+ div");
    el.className = "d-none mt-2";
  }
}
