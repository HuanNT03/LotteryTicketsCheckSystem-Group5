import { Component, Input } from '@angular/core';
import { TicketResultViewModel } from '../../../view-models/search/ticket-result.view-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ticket-result-table',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './ticket-result-table.component.html',
  styleUrl: './ticket-result-table.component.scss'
})
export class TicketResultTableComponent {
  @Input() ticketResult!:TicketResultViewModel;
  constructor()
  {

  }
}
