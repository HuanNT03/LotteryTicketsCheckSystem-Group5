import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TicketResultViewModel } from '../../../view-models/search/ticket-result.view-model';

@Component({
  selector: 'app-ticket-results-search',
  standalone: true,
  imports: [
    NavbarComponent,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './ticket-results-search.component.html',
  styleUrl: './ticket-results-search.component.scss'
})
export class TicketResultsSearchComponent implements OnInit {
  public lotteryForm!: FormGroup;
  companies = [
    { id: 1, name: 'Company A' },
    { id: 2, name: 'Company B' },
    { id: 3, name: 'Company C' }
  ];
  ticketResults!:TicketResultViewModel;
  isAuthenticated:boolean = false;

  constructor() {}

  ngOnInit(): void {
    this.lotteryForm = new FormGroup({
      company: new FormControl(''),
      date: new FormControl(''),
      ticketNumber: new FormControl('')
    })
  }

  onSubmit(): void {
    
  }
}
