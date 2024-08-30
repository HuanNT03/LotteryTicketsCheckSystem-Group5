import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, NgModel, ReactiveFormsModule } from '@angular/forms';
import { TicketStatus, TicketViewModel } from '../../../view-models/search/ticket.view-model';
import { Status } from '../../../view-models/search/user-search.view-model';

@Component({
  selector: 'app-find-ticket',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    FormsModule
  ],
  templateUrl: './find-ticket.component.html',
  styleUrl: './find-ticket.component.scss'
})
export class FindTicketComponent {
  public searchForm!: FormGroup;
  companies = ['Company A', 'Company B', 'Company C']; 
  results: TicketViewModel[] = [
    {
      ticketNumber: "0965",
      prize: "Giải nhất",
      publicDate: new Date(2024,7,25),
      company: "company A",
      status: TicketStatus.Unpublish
    }
  ]; 

  constructor() { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      company: new FormControl(''),
      fromDate: new FormControl(''),
      toDate: new FormControl('')
    });
  }

  onSearch() {
    if (this.searchForm.valid) {
      const searchCriteria = this.searchForm.value;

    }
  }

  changeStatus()
  {

  }
}
