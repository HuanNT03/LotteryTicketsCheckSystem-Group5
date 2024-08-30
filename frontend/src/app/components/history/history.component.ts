import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { HistoryViewModel } from '../../view-models/search/search-history.view-model';

@Component({
  selector: 'app-history',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './history.component.html',
  styleUrl: './history.component.scss'
})
export class HistoryComponent {
  @Input() user:string = "username";
  historySearch:HistoryViewModel[] = [
    { ticketNumber: '123456', publicDate: new Date(2024, 8, 28), result: 'Win', searchTime: new Date(2024, 8, 28) },
    { ticketNumber: '654321', publicDate: new Date(2024, 8, 28), result: 'Lose', searchTime: new Date(2024, 8, 28) },
    { ticketNumber: '112233', publicDate: new Date(2024, 8, 28), result: 'Win', searchTime: new Date(2024, 8, 28) },
    { ticketNumber: '445566', publicDate: new Date(2024, 8, 28), result: 'Lose', searchTime: new Date(2024, 8, 28) }
  ];
}
