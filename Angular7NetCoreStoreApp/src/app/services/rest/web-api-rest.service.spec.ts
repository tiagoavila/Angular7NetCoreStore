import { TestBed } from '@angular/core/testing';

import { WebApiRestService } from './web-api-rest.service';

describe('WebApiRestService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WebApiRestService = TestBed.get(WebApiRestService);
    expect(service).toBeTruthy();
  });
});
