import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanbylidComponent } from './loanbylid.component';

describe('LoanbylidComponent', () => {
  let component: LoanbylidComponent;
  let fixture: ComponentFixture<LoanbylidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoanbylidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoanbylidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
