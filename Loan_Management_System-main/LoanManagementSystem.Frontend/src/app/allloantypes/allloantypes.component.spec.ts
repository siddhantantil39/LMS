import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllloantypesComponent } from './allloantypes.component';

describe('AllloantypesComponent', () => {
  let component: AllloantypesComponent;
  let fixture: ComponentFixture<AllloantypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllloantypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllloantypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
