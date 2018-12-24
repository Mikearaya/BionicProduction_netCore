

export class VendorViewModel {

  id: number;
  name: string;
  phoneNumber: string;
  tinNumber: string;
  leadTime: number | null;
  paymentPeriod: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}


export class VendorModel {
  Id?: number;
  Name: string;
  PhoneNumber: string;
  TinNumber: string;
  LeadTime: number | null;
  PaymentPeriod: number | null;

}
