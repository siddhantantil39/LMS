import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetallpaymentsComponent } from './getallpayments.component';

describe('GetallpaymentsComponent', () => {
  let component: GetallpaymentsComponent;
  let fixture: ComponentFixture<GetallpaymentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetallpaymentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetallpaymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
