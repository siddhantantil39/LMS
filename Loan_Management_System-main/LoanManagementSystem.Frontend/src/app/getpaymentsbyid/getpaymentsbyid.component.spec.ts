import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetpaymentsbyidComponent } from './getpaymentsbyid.component';

describe('GetpaymentsbyidComponent', () => {
  let component: GetpaymentsbyidComponent;
  let fixture: ComponentFixture<GetpaymentsbyidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetpaymentsbyidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetpaymentsbyidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
