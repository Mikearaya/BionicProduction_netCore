import { CustomErrorResponse } from './system-data-models';

export abstract class CommonProperties {
  protected errorMessage: string;
  protected errorDescription: any;

  protected handleError(errorResponse: CustomErrorResponse): void {

    switch (errorResponse.errorNumber) {
      case 400:
        console.error(`${errorResponse.message}`);
        break;
      case 404:
        alert('Customer Order Not Found');
        this.errorMessage = errorResponse.message;
        break;
      case 422:
        alert(`${errorResponse.message}\n ${JSON.stringify(errorResponse.errorDetail)}`);
        this.errorDescription = errorResponse.errorDetail;
        this.errorMessage = errorResponse.message;
        break;
      case 423:
        alert('Can not Delete Customer order because it\'s being linked by other part of the system');
        this.errorDescription = errorResponse.errorDetail;
        this.errorMessage = errorResponse.message;
        break;
      default:
        alert('Unknown Error Occured, Please Try Again later');
        this.errorMessage = errorResponse.message;
        break;
    }
  }

}
