import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketResultTableComponent } from './ticket-result-table.component';

describe('TicketResultTableComponent', () => {
  let component: TicketResultTableComponent;
  let fixture: ComponentFixture<TicketResultTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TicketResultTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketResultTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
