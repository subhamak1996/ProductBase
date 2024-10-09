import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutputCompComponent } from './output-comp.component';

describe('OutputCompComponent', () => {
  let component: OutputCompComponent;
  let fixture: ComponentFixture<OutputCompComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OutputCompComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OutputCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
