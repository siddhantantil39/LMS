import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetpaymentsbycustidComponent } from './getpaymentsbycustid.component';

describe('GetpaymentsbycustidComponent', () => {
  let component: GetpaymentsbycustidComponent;
  let fixture: ComponentFixture<GetpaymentsbycustidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetpaymentsbycustidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetpaymentsbycustidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
