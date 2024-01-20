import { Component } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { sitePageTitle } from '../../constants/general.constants';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [TrCurrencyPipe],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  pageTitle = sitePageTitle + "Orders Page";
  title = "Orders";
}
