import { TestBed } from '@angular/core/testing';

import { ScrapServiceService } from './scrap-service.service';

describe('ScrapServiceService', () => {
  let service: ScrapServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScrapServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
