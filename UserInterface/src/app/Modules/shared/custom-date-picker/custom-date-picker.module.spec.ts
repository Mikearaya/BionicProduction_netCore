import { CustomDatePickerModule } from './custom-date-picker.module';

describe('CustomDatePickerModule', () => {
  let customDatePickerModule: CustomDatePickerModule;

  beforeEach(() => {
    customDatePickerModule = new CustomDatePickerModule();
  });

  it('should create an instance', () => {
    expect(customDatePickerModule).toBeTruthy();
  });
});
