/*
 * @CreateTime: Nov 4, 2018 9:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:06 AM
 * @Description: Modify Here, Please
 */
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invoice-payment',
  templateUrl: './invoice-payment.component.html',
  styleUrls: ['./invoice-payment.component.css']
})
export class InvoicePaymentComponent implements OnInit {

  public invoice: { paidAmount: number; remainingAmount: number; totalAmount: number; id: any; dueDate: Date; };

  constructor() {
    this.invoice = {
      paidAmount: 0,
      remainingAmount: 0,
      totalAmount: 0,
      dueDate: null,
      id: null
    };
  }

  ngOnInit() {

  }

}
