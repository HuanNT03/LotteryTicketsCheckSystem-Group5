import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoUserLayoutComponent } from './no-user-layout.component';

describe('NoUserLayoutComponent', () => {
  let component: NoUserLayoutComponent;
  let fixture: ComponentFixture<NoUserLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NoUserLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NoUserLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
