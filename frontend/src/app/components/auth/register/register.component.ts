import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, NgModel, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  public registerForm!:FormGroup;
  // public registerObj:any = ({
  //   username: '',
  //   email: '',
  //   password: '',
  //   confirmPassword: ''
  // })

  constructor()
  {

  }

  ngOnInit()
  {
    this.registerForm = new FormGroup({
      username: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmPassword: new FormControl('', Validators.required)
    });
  }

  
  onSubmit()
  {
    if (this.registerForm.valid)
      {
        console.log("Form Submited", this.registerForm.value);
      }
  }
}
