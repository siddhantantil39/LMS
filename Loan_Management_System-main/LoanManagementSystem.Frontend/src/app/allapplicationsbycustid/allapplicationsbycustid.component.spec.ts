import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllapplicationsbycustidComponent } from './allapplicationsbycustid.component';

describe('AllapplicationsbycustidComponent', () => {
  let component: AllapplicationsbycustidComponent;
  let fixture: ComponentFixture<AllapplicationsbycustidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllapplicationsbycustidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllapplicationsbycustidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
