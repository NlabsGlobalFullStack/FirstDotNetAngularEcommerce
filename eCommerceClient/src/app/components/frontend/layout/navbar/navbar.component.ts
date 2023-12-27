import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../../services/auth.service';
import { BasketService } from '../../../../services/basket.service';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-navbar',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [RouterLink],

  // Bileşenin kullanacağı HTML şablonunu belirler.
  templateUrl: './navbar.component.html',

  // Bileşenin kullanacağı CSS dosyasının yolunu belirler.
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  // AuthService ve BasketService servislerine bağımlılıkları enjekte eden yapıcı metot.
  constructor(
    public auth: AuthService,
    public cart: BasketService,
    private router: Router
  ){
    // Sayfa yüklendiğinde kimlik doğrulama durumunu kontrol eder.
    this.auth.isAuthenticated();
  }

  // Kullanıcı çıkış yapma işlemi.
  logout(){
    // Local storage'tan "response" anahtarını kaldırarak kullanıcıyı çıkış yapar.
    localStorage.removeItem("response");
    
    // Çıkış yapıldıktan sonra kimlik doğrulama durumunu günceller.
    this.auth.isAuthenticated();

    // Anasayfaya yönlendirme yapar.
    this.router.navigateByUrl("/");
  }
}
