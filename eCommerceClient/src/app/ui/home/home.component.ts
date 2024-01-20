import { Component } from '@angular/core';
import { TrCurrencyPipe } from 'tr-currency';
import { ProductModel } from '../../models/product.model';
import { AuthService } from '../../servives/auth.service';
import { sitePageTitle } from '../../constants/general.constants';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [TrCurrencyPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  pageTitle = sitePageTitle + "Home Page";
  title = "Home";
  products: ProductModel[] = [];
  isAuthenticated: boolean = false;

  constructor(private auth: AuthService){
  }
}
