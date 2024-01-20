import { Component } from '@angular/core';
import { sitePageTitle } from '../../constants/general.constants';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  pageTitle = sitePageTitle + "Register Page";
}
