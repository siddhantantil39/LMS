import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoantypenameComponent } from './loantypename.component';

describe('LoantypenameComponent', () => {
  let component: LoantypenameComponent;
  let fixture: ComponentFixture<LoantypenameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoantypenameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoantypenameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
