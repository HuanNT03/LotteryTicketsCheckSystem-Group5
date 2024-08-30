import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketManagementLayoutComponent } from './ticket-management-layout.component';

describe('TicketManagementLayoutComponent', () => {
  let component: TicketManagementLayoutComponent;
  let fixture: ComponentFixture<TicketManagementLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TicketManagementLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketManagementLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
