

export class OrderBookingView {
  id: number;
  customer: string;
  orderItems: CustomerOrderBooking[] = [];
}

export class CustomerOrderBooking {
id: number;
productName: string;
inStock: number;
availableAmount: number;
bookedAmount: number;
remainingAmount: number;
neededAmount: number;
afterBooking: number;

}

export class BulckBookingModel {
  createManufactureOrder: boolean;
  customerOrderId: number;
  Items: BookingModel[];
  workStartDate: Date;
  workEndDate: Date;
}

export class BookingModel {
  CreateManufactureOrder: boolean;
  CustomerOrderItemId: number;
  Quantity: number;
  BookedBy: number;
}
