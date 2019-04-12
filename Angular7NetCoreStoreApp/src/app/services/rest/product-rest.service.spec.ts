import { TestBed } from '@angular/core/testing';

import { ProductRestService } from './product-rest.service';

describe('ProductRestService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductRestService = TestBed.get(ProductRestService);
    expect(service).toBeTruthy();
  });
});
