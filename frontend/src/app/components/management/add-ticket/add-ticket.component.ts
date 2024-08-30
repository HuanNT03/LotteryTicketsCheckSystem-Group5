import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-ticket',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './add-ticket.component.html',
  styleUrl: './add-ticket.component.scss'
})
export class AddTicketComponent {
  lotteryForm!: FormGroup;
  companies: string[] = ['Công ty 1', 'Công ty 2', 'Công ty 3']; // Replace with actual company names
  prizes: string[] = ['Giải Đặc Biệt', 'Giải Nhất', 'Giải Nhì', 'Giải Ba', 'Giải Bốn']; // Replace with actual prize names

  constructor() {}

  ngOnInit() {
    this.lotteryForm = new FormGroup({
      date: new FormControl(''),
      company: new FormControl(''),
      prize: new FormControl(''),
      status: new FormControl('unpublish'),
      lotteryNumber: new FormControl(''),
    });
  }

  onSubmit() {
    console.log(this.lotteryForm.value);
    // Handle form submission, send data to the API
  }
}
