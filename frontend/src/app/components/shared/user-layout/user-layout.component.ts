import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";
import { TicketResultTableComponent } from '../ticket-result-table/ticket-result-table.component';
import { CommonModule } from '@angular/common';
import { TicketResultViewModel } from '../../../view-models/search/ticket-result.view-model';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-user-layout',
  standalone: true,
  imports: [
    NavbarComponent,
    TicketResultTableComponent,
    CommonModule,
    RouterOutlet
  ],
  templateUrl: './user-layout.component.html',
  styleUrl: './user-layout.component.scss'
})
export class UserLayoutComponent {
  public ticketResults: TicketResultViewModel[] = []
  constructor()
  {

  }

  ngOnInit()
  {

  }
}
