import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketResultsSearchComponent } from './ticket-results-search.component';

describe('TicketResultsSearchComponent', () => {
  let component: TicketResultsSearchComponent;
  let fixture: ComponentFixture<TicketResultsSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TicketResultsSearchComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketResultsSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
