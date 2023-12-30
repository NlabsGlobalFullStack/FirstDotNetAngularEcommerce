import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

// Angular enjekte edilebilir servisleri temsil eden dekoratör.
@Injectable({
  // Servisin hangi modül tarafından sağlandığını belirler.
  providedIn: 'root'
})
export class BasketService {
  // Sepet içindeki öğe sayısını tutan değişken.
  apiUrl: string = "https://localhost:7031/api/Baskets/GetAll/";
  count: number = 0;

  // HttpClient servisine bağımlılığı enjekte eden servis yapıcı metodu.
  constructor(private http: HttpClient) {
    // Sayfa yüklendiğinde sepet öğe sayısını almak için getCount() metodunu çağırır.
    this.getCount();
  }

  // Sepet içindeki öğe sayısını almak için API'yi çağıran metod.
  getCount() {
    // HttpClient servisi aracılığıyla belirli bir API'yi çağırır.
    this.http.get(this.apiUrl)
      .subscribe({
        // API çağrısı başarılıysa bu blok çalışır.
        next: ((res: any) => {
          // API yanıtından gelen öğe sayısını servis içindeki değişkene atar.
          this.count = res.count;
        }),
        // API çağrısı başarısızsa bu blok çalışır.
        error: (err: HttpErrorResponse) => {
          // Hata durumunu konsola yazdırır.
          console.log(err);
        }
      });
  }
}
