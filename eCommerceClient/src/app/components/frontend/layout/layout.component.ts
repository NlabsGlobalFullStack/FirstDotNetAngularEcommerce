import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-layout',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [RouterOutlet, NavbarComponent],

  // Bileşenin kullanacağı HTML şablonunu belirler.
  templateUrl: './layout.component.html',

  // Bileşenin kullanacağı CSS dosyasının yolunu belirler.
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  // Boş, çünkü bu bileşen sadece düzeni temsil eder.
}
