import { ActivatedRoute } from '@angular/router';
import { BomApiService } from 'src/app/Modules/core/services/bom/bom-api.service';
import { BomView } from 'src/app/Modules/core/DataModels/bom.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { RoutingApiService } from 'src/app/Modules/core/services/production-routing/routing-api.service';
import {
  RoutingDetailViewModel,
  RoutingModel,
  RoutingOperationModel,
  RoutingOperationViewModel,
  RoutingBomsModel
} from 'src/app/Modules/core/DataModels/production-routing.model';
import { WorkStationApiService } from 'src/app/Modules/core/services/work-station/work-station-api.service';
import { WorkstationGroupView } from 'src/app/Modules/core/DataModels/workstation.model';
import { ProductsAPIService, Product } from 'src/app/Modules/core/services/items/products-api.service';
import { ItemApiService } from 'src/app/Modules/core/services/stock/stock-api.service';
import { DropDownListComponent } from '@syncfusion/ej2-angular-dropdowns';
import { Query } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-routing-form',
  templateUrl: './routing-form.component.html',
  styleUrls: ['./routing-form.component.css']
})
export class RoutingFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  @ViewChild('bomDropdown')
  public bomDropdown: DropDownListComponent;
  @ViewChild('itemDropdown')
  public itemDropdown: DropDownListComponent;

  public routingForm: FormGroup;
  public title: String;
  public submitButtonText: String;
  private routingId: number;
  public isUpdate: Boolean;
  public itemsList: Product[];
  public itemFields: { text: string, value: string };
  public bomsList: BomView[];
  public bomFields: { text: string, value: string };
  public workstationsList: WorkstationGroupView[];
  public workstationFields: { text: string, value: string };
  selectedItemId: number;


  constructor(private routingApi: RoutingApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private workstationApi: WorkStationApiService,
    private itemApi: ProductsAPIService,
    private bomApi: BomApiService) {
    super();
    this.createForm();

    this.bomFields = { text: 'name', value: 'id' };
    this.itemFields = { text: 'name', value: 'id' };
    this.workstationFields = { text: 'name', value: 'id' };
  }

  ngOnInit() {
    this.routingId = + this.activatedRoute.snapshot.paramMap.get('routingId');
    this.selectedItemId = + this.activatedRoute.snapshot.paramMap.get('itemId');

    this.itemApi.getAllProducts().subscribe(
      (data: any) => this.itemsList = data.Items,
      this.handleError
    );


    if (this.selectedItemId) {
      this.bomApi.getItemBOMsById(this.selectedItemId).subscribe(
        (data: BomView[]) => this.bomsList = data,
        this.handleError
      );
    } else {
      this.bomApi.getAllBomItems().subscribe(
        (data: BomView[]) => this.bomsList = data,
        this.handleError
      );
    }

    this.workstationApi.getWorkStationGroups().subscribe(
      (data: WorkstationGroupView[]) => this.workstationsList = data,
      this.handleError
    );

    this.isUpdate = false;
    this.submitButtonText = 'Save';
    this.title = `Create new product routing`;


    if (this.routingId) {
      this.isUpdate = true;
      this.submitButtonText = 'Update';
      this.title = `Update routing #${this.routingId}`;

      this.routingApi.getProductionRoutingById(this.routingId).subscribe(
        (data: RoutingDetailViewModel) => this.initializeForm(data)
      );
    }



  }

  private createForm(): void {
    this.routingForm = this.formBuilder.group({
      routName: ['', Validators.required],
      itemId: ['', Validators.required],
      otherCostQuantity: [''],
      otherFixedCost: [''],
      otherVariableCost: [''],
      routingBoms: [''],
      note: [''],
      operations: this.formBuilder.array([
        this.createRoutingOperation()
      ]),
      boms: ['']

    });
  }

  private initializeForm(route: RoutingDetailViewModel): void {
    this.routingForm = this.formBuilder.group({
      routName: [route.name, Validators.required],
      itemId: [route.itemId, Validators.required],
      otherCostQuantity: [route.quantity],
      otherFixedCost: [route.otherVariableCost],
      otherVariableCost: [route.otherVariableCost],
      routingBoms: [''],
      note: [''],
      operations: this.formBuilder.array(route.routingOperations.map(o => this.initializeRoutingOperation(o))
      ),
      boms: [route.routingBoms.map(b => b.bomId)]

    });
  }


  private createRoutingOperation(): FormGroup {
    return this.formBuilder.group({
      workstationId: ['', Validators.required],
      operation: ['', Validators.required],
      fixedCost: [''],
      fixedTime: [''],
      variableCost: [''],
      variableTime: [''],
      quantity: ['', [Validators.required, Validators.min(0)]]
    });
  }




  private initializeRoutingOperation(route: RoutingOperationViewModel): FormGroup {
    return this.formBuilder.group({
      workstationId: [route.workstationId, Validators.required],
      operation: [route.operation, Validators.required],
      fixedCost: [route.fixedCost],
      fixedTime: [route.fixedTime],
      variableCost: [route.variableCost],
      variableTime: [route.variableTime],
      quantity: [route.quantity, [Validators.required, Validators.min(0)]]
    });
  }

  get boms(): FormControl {
    return this.routingForm.get('boms') as FormControl;
  }

  get routingOperations(): FormArray {
    return this.routingForm.get('operations') as FormArray;
  }

  get routeName(): FormControl {
    return this.routingForm.get('routName') as FormControl;
  }

  get routeItemId(): FormControl {
    return this.routingForm.get('itemId') as FormControl;
  }
  get otherVariableCost(): FormControl {
    return this.routingForm.get('otherVariableCost') as FormControl;
  }

  get otherFixedCost(): FormControl {
    return this.routingForm.get('otherFixedCost') as FormControl;
  }

  get otherCostQuantity(): FormControl {
    return this.routingForm.get('otherCostQuantity') as FormControl;
  }

  get note(): FormControl {
    return this.routingForm.get('note') as FormControl;
  }

  onSubmit(): void {
    const routingData = this.prepareFormData();

    if (this.isUpdate && routingData) {
      this.routingApi.updateRouting(routingData).subscribe(
        () => this.notification.showMessage('Routing information updated successfuly'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Routing information Could not be updated successfuly, Try Again', 'error');
          this.handleError(error);
        }
      );
    } else if (routingData) {
      this.routingApi.createRouting(routingData).subscribe(
        () => {
          this.notification.showMessage('Routing information Created successfuly');
          this.routingForm.reset();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Routing information Could not be Created successfuly, Try Again', 'error');
          this.handleError(error);
        }
      );
    }

  }

  private prepareFormData(): RoutingModel | null {

    if (this.routingForm.valid) {
      const formData = this.routingForm.value;
      const routing = new RoutingModel();
      routing.id = this.routingId ? this.routingId : 0;
      routing.name = this.routeName.value;
      routing.quantity = this.otherCostQuantity.value;
      routing.fixedCost = this.otherFixedCost.value;
      routing.variableCost = this.otherVariableCost.value;
      routing.itemId = this.routeItemId.value;
      routing.note = this.note.value;

      this.routingOperations.controls.forEach(element => {
        const op = new RoutingOperationModel();
        op.workstationId = element.value.workstationId;
        op.operation = (element.value.operation) ? element.value.operation : 0;
        op.fixedCost = (element.value.fixedCost) ? element.value.fixedCost : 0;
        op.fixedTime = (element.value.fixedTime) ? element.value.fixedTime : 0;
        op.variableCost = element.value.variableCost ? element.value.variableCost : 0;
        op.variableTime = element.value.variableTime ? element.value.variableTime : 0;
        op.quantity = element.value.quantity;
        routing.Operations.push(op);
      });

      this.boms.value.forEach(element => {
        const bom = new RoutingBomsModel();
        bom.bomId = element;
        bom.routingId = (this.routingId) ? this.routingId : 0;
        routing.Boms.push(bom);
      });
      return routing;

    } else {
      return null;
    }


  }

  itemChanged(): void {

    if (!!this.itemDropdown.value) {

      this.bomApi.getItemBOMsById(this.itemDropdown.value as number).subscribe(
        (data: BomView[]) => this.bomsList = data,
        this.handleError
      );
      this.bomDropdown.text = null;
      this.bomDropdown.dataBind();
    }

  }
  createWorkstationGroup(): void {

  }

  addOperation(): void {
    this.routingOperations.push(this.createRoutingOperation());
  }

  removeOperation(index: number): void {
    this.routingOperations.removeAt(index);
  }

}
