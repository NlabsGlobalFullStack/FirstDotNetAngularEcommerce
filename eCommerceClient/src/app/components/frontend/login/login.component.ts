import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-login',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [RouterLink, FormsModule],

  // Bileşenin kullanacağı HTML şablonunu belirler.
  templateUrl: './login.component.html',

  // Bileşenin kullanacağı CSS dosyasının yolunu belirler.
  styleUrl: './login.component.css'
})
export class LoginComponent {
  apiUrl: string = "https://localhost:7031/api/Auth/";
  // Bileşenin yapıcı metodu.
  constructor(private http: HttpClient, private router: Router){}

  // Kullanıcının giriş yapmasını sağlayan metod.
  signIn(form: NgForm) {
    // Formun geçerli olup olmadığını kontrol eder.
    if(form.valid){
      // HTTP POST isteği yaparak kullanıcıyı giriş yapmış gibi simüle eder.
      this.http.post(this.apiUrl + "Login/", form.value)
        .subscribe({
          next: (res: any)=> {
            // Giriş başarılıysa kullanıcı bilgilerini local storage'a kaydeder.
            localStorage.setItem("response", JSON.stringify(res));
            
            // Anasayfaya yönlendirme yapar.
            this.router.navigateByUrl("/");
          },
          error: (err: HttpErrorResponse)=> {
            console.log(err);          
          }
        });
    }
  }
}
