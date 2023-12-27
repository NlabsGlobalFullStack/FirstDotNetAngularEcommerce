import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-register',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [RouterLink, FormsModule],

  // Bileşenin kullanacağı HTML şablonunu belirler.
  templateUrl: './register.component.html',

  // Bileşenin kullanacağı CSS dosyasının yolunu belirler.
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  // Bileşenin yapıcı metodu.
  constructor(
    private http: HttpClient,
    private router: Router
  ){}

  // Kullanıcı kaydını yapmak için kullanılan metod.
  signUp(form: NgForm){
    // Formun geçerli olup olmadığını kontrol eder.
    if(form.valid){
      // HTTP POST isteği yaparak kullanıcıyı kaydeder.
      this.http.post("", form.value)
        .subscribe({
          next: (res: any)=> {
            // Kayıt başarılıysa kullanıcıyı giriş sayfasına yönlendirir.
            this.router.navigateByUrl("/login");
          },
          error: (err: HttpErrorResponse)=> {
            console.log(err);          
          }
        });
    }
  }
}
