import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetProductTypeComponent } from './get-product-type.component';

describe('GetProductTypeComponent', () => {
  let component: GetProductTypeComponent;
  let fixture: ComponentFixture<GetProductTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetProductTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetProductTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
