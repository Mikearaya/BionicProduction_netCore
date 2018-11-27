/*
 * @CreateTime: Nov 26, 2018 8:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 8:39 PM
 * @Description: Modify Here, Please
 */
export class Customer {
  id?: number;
  fullName: string;
  creditLimit?: number;
  paymentPeriod?: number;
  tin?: string;
  type: string;
  fax?: string;
  poBox?: string;
  email: string;
  telephones: TelephoneAddress[] = [];
  socialMedias: SocialMediaAddress[] = [];
  addresses: Address[] = [];
}

export class Address {
  id?: number;
  location: string;
  subCity: string;
  city: string;
  country: string;
  phoneNumber?: string;
}

export class TelephoneAddress {
  id?: number;
  type: string;
  number: string;
}

export class SocialMediaAddress {
  id: number;
  site: string;
  address: string;
}


