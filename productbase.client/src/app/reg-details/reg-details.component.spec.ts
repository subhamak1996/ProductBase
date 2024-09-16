import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegDetailsComponent } from './reg-details.component';

describe('RegDetailsComponent', () => {
  let component: RegDetailsComponent;
  let fixture: ComponentFixture<RegDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
