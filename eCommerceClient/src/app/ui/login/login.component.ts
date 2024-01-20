import { Component } from '@angular/core';
import { sitePageTitle } from '../../constants/general.constants';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    pageTitle = sitePageTitle + "Login Page";
}
