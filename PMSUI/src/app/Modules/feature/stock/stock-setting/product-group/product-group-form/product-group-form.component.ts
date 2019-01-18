import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProductGroupView, ProductGroup } from 'src/app/Modules/core/DataModels/product-group.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Location } from '@angular/common';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { ProductGroupApiService } from 'src/app/Modules/core/services/product-group/product-group-api.service';

@Component({
  selector: 'app-product-group-form',
  templateUrl: './product-group-form.component.html',
  styleUrls: ['./product-group-form.component.css']
})
export class ProductGroupFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  private groupId: number;
  public isUpdate: Boolean;
  public title = 'Create Product Group';
  public submitButtonText: string;
  public productGroupForm: FormGroup;
  public productGroupsList: ProductGroupView[];
  public productGroupFields: { text: string, value: string };

  constructor(private productGroupApi: ProductGroupApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    super();
    this.createForm();
    this.productGroupFields = { text: 'groupName', value: 'id' };
  }

  ngOnInit() {
    this.groupId = + this.activatedRoute.snapshot.paramMap.get('groupId');

    this.productGroupApi.getAllProductGroups().subscribe(
      (data: ProductGroupView[]) => this.productGroupsList = data,
      this.handleError
    );

    if (this.groupId) {

      this.isUpdate = true;
      this.submitButtonText = 'Update';
      this.title = 'Update Product Group';

      this.productGroupApi.getProductGroupById(this.groupId).subscribe(
        (data: ProductGroupView) => this.initializeForm(data),
        this.handleError
      );

    } else {

      this.isUpdate = false;
      this.title = 'Create New Product Group';
      this.submitButtonText = 'Save';
    }
  }

  get groupName(): FormControl {
    return this.productGroupForm.get('groupName') as FormControl;
  }

  get description(): FormControl {
    return this.productGroupForm.get('groupName') as FormControl;
  }

  get parentId(): FormControl {
    return this.productGroupForm.get('groupName') as FormControl;
  }

  private createForm(): void {
    this.productGroupForm = this.formBuilder.group({
      groupName: ['', Validators.required],
      description: [''],
      parentId: ['']
    });
  }

  private initializeForm(group: ProductGroupView): void {

    this.productGroupForm = this.formBuilder.group({
      id: [group.id, Validators.required],
      groupName: [group.groupName, Validators.required],
      description: [group.description],
      parentId: [group.parentGroupId]
    });
  }

  onSubmit(): void {
    if (!this.productGroupForm.invalid) {
      const productGroup = this.prepareFormData(this.productGroupForm.value);

      if (!this.isUpdate) {
        this.productGroupApi.CreateProductGroup(productGroup).subscribe(
          (result) => {
            this.notification.showMessage('Product Group Created', 'success');
            this.location.back();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unable to create product group', 'error');
            this.handleError(error);
          }
        );
      } else {
        this.productGroupApi.UpdateProductGroup(productGroup).subscribe(
          () => {
            this.notification.showMessage('Product Group Updated', 'success');
            this.location.back();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unable to Update product group', 'error');
            this.handleError(error);
          }
        );
      }
    }

  }

  private prepareFormData(formData: any): ProductGroup {
    return {
      id: (this.groupId) ? this.groupId : 0,
      GroupName: formData.groupName,
      Description: formData.description,
      ParentGroup: (formData.parentId) ? formData.parentId : 0,

    };
  }



}
