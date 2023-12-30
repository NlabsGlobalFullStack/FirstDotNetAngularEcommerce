import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

// Angular bileşeni için dekoratör ile temel yapıyı tanımlar.
@Component({
  // Bileşenin HTML öğeleri içinde kullanılacak adı belirler.
  selector: 'app-root',

  // Bileşenin kendi başına bir bileşen olarak çalışmasını sağlar.
  standalone: true,

  // Bileşenin kullanacağı ek modülleri içerir.
  imports: [RouterOutlet],

  // Bileşenin görünümünü ve davranışını tanımlayan HTML şablonu.
  template: "<router-outlet></router-outlet>"
})
export class AppComponent {
}
