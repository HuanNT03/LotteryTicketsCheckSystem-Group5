import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-change-password',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.scss'
})
export class ChangePasswordComponent {
  changePasswordForm!: FormGroup;

  user:string = "username"

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.changePasswordForm = new FormGroup({
      password: new FormControl(''),
      newPassword: new FormControl(''),
      confirmPassword: new FormControl('')
    });
  }

  checkPasswords() {
    return this.changePasswordForm
  }

  onSubmit() {
    if (this.changePasswordForm.valid) {
      console.log('Form Submitted', this.changePasswordForm.value);
    } else {
      console.log('Form is invalid');
    }
  }
}
