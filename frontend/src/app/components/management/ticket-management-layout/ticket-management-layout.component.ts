import { Component } from '@angular/core';
import { AddTicketComponent } from "../add-ticket/add-ticket.component";
import { FindTicketComponent } from '../find-ticket/find-ticket.component';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-ticket-management-layout',
  standalone: true,
  imports: [AddTicketComponent,
    FindTicketComponent,
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './ticket-management-layout.component.html',
  styleUrl: './ticket-management-layout.component.scss'
})
export class TicketManagementLayoutComponent {

}
