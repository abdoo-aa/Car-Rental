import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArhampayComponent } from './arhampay.component';

describe('ArhampayComponent', () => {
  let component: ArhampayComponent;
  let fixture: ComponentFixture<ArhampayComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArhampayComponent]
    });
    fixture = TestBed.createComponent(ArhampayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
