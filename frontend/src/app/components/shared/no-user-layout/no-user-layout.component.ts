import { Component, Input } from '@angular/core';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";
import { TicketResultTableComponent } from "../ticket-result-table/ticket-result-table.component";
import { TicketResultViewModel } from '../../../view-models/search/ticket-result.view-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-no-user-layout',
  standalone: true,
  imports: [
    NavbarComponent, TicketResultTableComponent,
    CommonModule
  ],
  templateUrl: './no-user-layout.component.html',
  styleUrl: './no-user-layout.component.scss'
})
export class NoUserLayoutComponent {
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
  }]



  constructor()
  {

  }
}
