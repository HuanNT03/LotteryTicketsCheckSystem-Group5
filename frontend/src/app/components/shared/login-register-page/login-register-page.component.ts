import { Component } from '@angular/core';
import { LoginComponent } from "../../auth/login/login.component";
import { RegisterComponent } from "../../auth/register/register.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login-register-page',
  standalone: true,
  imports: [
    LoginComponent, 
    RegisterComponent,
    CommonModule
  ],
  templateUrl: './login-register-page.component.html',
  styleUrl: './login-register-page.component.scss'
})
export class LoginRegisterPageComponent {
  public hasAccount:boolean = true;

  constructor()
  {

  }

  changeToRegister()
  {
    if (this.hasAccount == true)
    this.hasAccount = false;
  }
  changeToLogin()
  {
    if (this.hasAccount == false)
    this.hasAccount = true;
  }
}
