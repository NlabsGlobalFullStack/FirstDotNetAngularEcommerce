import { Injectable } from '@angular/core';

// Angular enjekte edilebilir servisleri temsil eden dekoratör.
@Injectable({
  // Servisin hangi modül tarafından sağlandığını belirler.
  providedIn: 'root'
})
export class AuthService {
  // Kullanıcının kimlik doğrulamasının durumunu tutan değişken.
  hasAuthenticated: boolean = false;

  // AuthService servisinin yapıcı metodu.
  constructor() { }

  // Kullanıcının kimlik doğrulama durumunu kontrol eden metod.
  isAuthenticated() {
    // Local storage'tan "response" anahtarına sahip bir değeri alır.
    const responseString = localStorage.getItem("response");

    // Eğer değer varsa, kullanıcı kimlik doğrulaması yapılmıştır.
    if (responseString) {
      // Kimlik doğrulama durumunu true olarak ayarlar.
      this.hasAuthenticated = true;
      return true;
    }

    // Eğer değer yoksa, kullanıcı kimlik doğrulaması yapılmamıştır.
    this.hasAuthenticated = false;
    return false;
  }
}
