import { Component } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { sitePageTitle } from '../../constants/general.constants';

@Component({
  selector: 'app-shopping-cart',
  standalone: true,
  imports: [TrCurrencyPipe],
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css'
})
export class ShoppingCartComponent {
  pageTitle = sitePageTitle + "Basket Page";
  title = "Basket";
}
