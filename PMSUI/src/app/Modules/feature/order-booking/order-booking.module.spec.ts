import { OrderBookingModule } from './order-booking.module';

describe('OrderBookingModule', () => {
  let orderBookingModule: OrderBookingModule;

  beforeEach(() => {
    orderBookingModule = new OrderBookingModule();
  });

  it('should create an instance', () => {
    expect(orderBookingModule).toBeTruthy();
  });
});
