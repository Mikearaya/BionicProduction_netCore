// Custom DateAdapter

import {NgModule} from '@angular/core';
import {MatDatepickerModule, NativeDateModule, NativeDateAdapter, DateAdapter, MAT_DATE_FORMATS} from '@angular/material';

// extend NativeDateAdapter's format method to specify the date format.
export class CustomDateAdapter extends NativeDateAdapter {
   format(date: Date, displayFormat: Object): string {
     if ( displayFormat === 'input') {
         const day = date.getDate();
         const month = date.getMonth();
         const year = date.getFullYear();
         // Return the format as per your requirement
         return `${year}-${month}-${day}`;
     } else {
       return date.toDateString();
     }

   }
   // If required extend other NativeDateAdapter methods.
   parse(value: any): Date | null {
    if ((typeof value === 'string') && (value.indexOf('-') > -1)) {
      const str = value.split('-');
      const year = Number(str[2]);
      const month = Number(str[1]) - 1;
      const date = Number(str[0]);
      return new Date(year, month, date);
    }
      const timestamp = typeof value === 'number' ? value : Date.parse(value);
      return isNaN(timestamp) ? null : new Date(timestamp);


  }
}


const MY_DATE_FORMATS = {
   parse: 'YYYY-MM-dd',
   display: {
    dateInput: 'input',
    monthYearLabel: {year: 'numeric', month: 'short'},
    dateA11yLabel: {year: 'numeric', month: 'long', day: 'numeric'},
    monthYearA11yLabel: {year: 'numeric', month: 'long'},
   }
};

@NgModule({
   declarations: [],
   imports: [],
   exports: [MatDatepickerModule, NativeDateModule],
   providers: [
      {
         provide: DateAdapter, useClass: CustomDateAdapter
      },
      {
         provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS
      }
   ]
})

export class CustomDatePickerModule { }
