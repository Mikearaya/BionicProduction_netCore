import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderBookingView, BulckBookingModel, BookingModel } from './order-booking-data';
import { Observable, of } from 'rxjs';

@Injectable()
export class BookingApiService {
  private url = 'booking';
  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) { }

  getCustomerOrderBookings(id: number): Observable<OrderBookingView> {
    return this.httpClient.get<OrderBookingView>(`${this.apiUrl}/salesorders/${id}/${this.url}`);
  }

  bookInBulck(orders: BulckBookingModel): Observable<OrderBookingView> {
    return this.httpClient.post<OrderBookingView>(`${this.apiUrl}/salesorders/${orders.customerOrderId}/${this.url}`, orders);
  }

  bookSingle(orderId: number, order: BookingModel): Observable<BookingModel> {
    return this.httpClient.post<BookingModel>(`${this.apiUrl}/salesorders/${orderId}/${this.url}`, order);
  }
}
