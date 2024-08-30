import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TicketResultViewModel } from '../../../view-models/search/ticket-result.view-model';
import { TicketResultTableComponent } from '../../shared/ticket-result-table/ticket-result-table.component';

@Component({
  selector: 'app-ticket-results-search',
  standalone: true,
  imports: [
    NavbarComponent,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TicketResultTableComponent
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
  ticketResults:TicketResultViewModel[] = [{
    companyName:'Xskt1',
    publicDate: new Date(2024, 8, 21),
    specialPrizes: [ '1234'],
    firstPrizes: [ '3445', '2345'],
    secondPrizes: ['9876', '5363'],
    thirdPrizes: ['6750', '2973'],
    fourthPrize: ['4601', '0927', '4621', '0127']
  },
  {
    companyName:'Xskt1',
    publicDate: new Date(2024, 8, 21),
    specialPrizes: [ '1234'],
    firstPrizes: [ '3445', '2345'],
    secondPrizes: ['9876', '5363'],
    thirdPrizes: ['6750', '2973'],
    fourthPrize: ['4601', '0927', '4621', '0127']
  },
  {
    companyName:'Xskt1',
    publicDate: new Date(2024, 8, 21),
    specialPrizes: [ '1234'],
    firstPrizes: [ '3445', '2345'],
    secondPrizes: ['9876', '5363'],
    thirdPrizes: ['6750', '2973'],
    fourthPrize: ['4601', '0927', '4621', '0127']
  }];
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
