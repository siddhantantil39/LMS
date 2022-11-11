import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllapplicationsbyappidComponent } from './allapplicationsbyappid.component';

describe('AllapplicationsbyappidComponent', () => {
  let component: AllapplicationsbyappidComponent;
  let fixture: ComponentFixture<AllapplicationsbyappidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllapplicationsbyappidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllapplicationsbyappidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
