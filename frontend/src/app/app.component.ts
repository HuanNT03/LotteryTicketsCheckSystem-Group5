import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./components/navbar/navbar/navbar.component";
import { LoginComponent } from "./components/auth/login/login.component";
import { RegisterComponent } from "./components/auth/register/register.component";
import { LoginRegisterPageComponent } from "./components/shared/login-register-page/login-register-page.component";
import { UserSearchComponent } from "./components/search/user-search/user-search.component";
import { TicketResultTableComponent } from "./components/shared/ticket-result-table/ticket-result-table.component";
import { NoUserLayoutComponent } from "./components/shared/no-user-layout/no-user-layout.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, LoginComponent, RegisterComponent, LoginRegisterPageComponent, UserSearchComponent, TicketResultTableComponent, NoUserLayoutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'frontend';
}
