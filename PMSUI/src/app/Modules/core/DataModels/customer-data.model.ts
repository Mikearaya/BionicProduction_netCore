/*
 * @CreateTime: Nov 26, 2018 8:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 26, 2018 9:01 PM
 * @Description: Modify Here, Please
 */
export class Customer {
  CUSTOMER_ID?: number;
  fullName: string;
  creditLimit?: number;
  paymentPeriod?: number;
  type: string;
  fax?: string;
  poBox?: string;
  email: string;
  telephones: TelephoneAddress[] = [];
  socialMedias: SocialMediaAddress[] = [];
  addresses: Address[] = [];
}

export class Address {
  location: string;
  subCity: string;
  city: string;
  country: string;
  phoneNumber?: string;
}

export class TelephoneAddress {
  type: string;
  number: string;
}

export class SocialMediaAddress {
  site: string;
  address: string;
}


