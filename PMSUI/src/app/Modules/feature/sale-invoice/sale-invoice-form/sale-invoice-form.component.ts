import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';

@Component({
  selector: 'app-sale-invoice-form',
  templateUrl: './sale-invoice-form.component.html',
  styleUrls: ['./sale-invoice-form.component.css']
})

export class SaleInvoiceFormComponent implements OnInit {
  public saleInvoiceForm: FormGroup;
  public discount: number;
  public totalTax: number;
  public totalBeforeTax: number;
  public totalAfterTax: number;
  public totalQuantity: number;
  public taxAmount: number;
  public invoiceTypes = ['Quotation', 'Pro-forma invoice', 'Invoice', 'Credit-invoice', 'Order confirmation'];
  public invoiceStatus = ['Paid', 'Not Paid'];

  constructor(private formBuilder: FormBuilder,
    private saleInvoiceApi: SaleInvoiceApiService) {

      this.createForm();
    }

  ngOnInit() {

    this.items.valueChanges
            .subscribe((data: any[]) => {
              this.discount = 0;
              this.totalQuantity = 0;
              this.totalBeforeTax = 0;
              this.totalAfterTax = 0;
              this.taxAmount = 0;
              data.forEach(element => {
                this.discount += element.discount;
                this.totalQuantity += element.quantity;
                this.totalBeforeTax += element.quantity * element.unitPrice;              });


            });

  }

get items(): FormArray {
  return this.saleInvoiceForm.get('items') as FormArray;
}
  invoiceItems(): FormGroup {
    return this.formBuilder.group({
      itemId: ['', Validators.required],
      quantity: [0, Validators.required],
      unitPrice: [0, Validators.required],
      discount: [0],
      subTotal: [0]
    });
  }

  createForm() {
    this.saleInvoiceForm = this.formBuilder.group({
      customerOrderId: [''],
      customerId: ['', Validators.required],
      invoiceType: ['', Validators.required],
      status: ['', Validators.required],
      dateAdded: ['', Validators.required],
      dueDate: ['', Validators.required],
      currencyId: ['', Validators.required],
      note: ['', Validators.required],
      totalDiscount: [0],
      tax: [0],
      items: this.formBuilder.array([
        this.invoiceItems()
      ])
    });
  }

  addItem() {
    this.items.push(this.invoiceItems());
  }

  removeItem(index: number) {
    this.items.removeAt(index);
  }


}
