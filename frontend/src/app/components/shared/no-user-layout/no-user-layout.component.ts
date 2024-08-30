import { Component, Input } from '@angular/core';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";
import { TicketResultTableComponent } from "../ticket-result-table/ticket-result-table.component";
import { TicketResultViewModel } from '../../../view-models/search/ticket-result.view-model';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-no-user-layout',
  standalone: true,
  imports: [
    NavbarComponent, TicketResultTableComponent,
    CommonModule,
    RouterOutlet
  ],
  templateUrl: './no-user-layout.component.html',
  styleUrl: './no-user-layout.component.scss'
})
export class NoUserLayoutComponent {
  
}
