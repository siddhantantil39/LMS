import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanbycustidComponent } from './loanbycustid.component';

describe('LoanbycustidComponent', () => {
  let component: LoanbycustidComponent;
  let fixture: ComponentFixture<LoanbycustidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoanbycustidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoanbycustidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
