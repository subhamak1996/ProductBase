import { TestBed } from '@angular/core/testing';

import { GetProductTypeService } from './get-product-type.service';

describe('GetProductTypeService', () => {
  let service: GetProductTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetProductTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
