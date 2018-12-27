import { TestBed, inject } from '@angular/core/testing';
import { ItemApiService } from './item-api.service';




describe('StockApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ItemApiService]
    });
  });

  it('should be created', inject([ItemApiService], (service: ItemApiService) => {
    expect(service).toBeTruthy();
  }));
});
