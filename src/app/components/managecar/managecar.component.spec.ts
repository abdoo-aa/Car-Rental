import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagecarComponent } from './managecar.component';

describe('ManagecarComponent', () => {
  let component: ManagecarComponent;
  let fixture: ComponentFixture<ManagecarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManagecarComponent]
    });
    fixture = TestBed.createComponent(ManagecarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
