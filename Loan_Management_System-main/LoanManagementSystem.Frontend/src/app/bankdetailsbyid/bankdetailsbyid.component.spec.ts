import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BankdetailsbyidComponent } from './bankdetailsbyid.component';

describe('BankdetailsbyidComponent', () => {
  let component: BankdetailsbyidComponent;
  let fixture: ComponentFixture<BankdetailsbyidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BankdetailsbyidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BankdetailsbyidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
