import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginViewModel } from '../view-models/auth/login.view-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // loginObj: LoginViewModel;

  // constructor(private http: HttpClient) 
  // {
  //   this.loginObj = new LoginViewModel();
  // }

  // onLogin()
  // {
  //   this.http.post('https://localhost:7112/api/Auth/login', this,this.loginObj).subscribe((response: any)=>{
  //     if(response)
  //   })
  // }
}
