import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetpaymentsbypidComponent } from './getpaymentsbypid.component';

describe('GetpaymentsbypidComponent', () => {
  let component: GetpaymentsbypidComponent;
  let fixture: ComponentFixture<GetpaymentsbypidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetpaymentsbypidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetpaymentsbypidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
