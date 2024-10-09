import { TestBed } from '@angular/core/testing';

import { GetProductDetailsService } from './get-product-details.service';

describe('GetProductDetailsService', () => {
  let service: GetProductDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetProductDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
