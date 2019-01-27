import { Component, OnInit, ViewChild } from '@angular/core';
import { SystemRoleApiService } from '../system-role-api.service';
import { SystemFunctionsModel, SystemRoleModel, SystemActionsModel, RoleDetailViewModel } from '../system-role-data.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-system-role-form',
  templateUrl: './system-role-form.component.html',
  styleUrls: ['./system-role-form.component.css']
})
export class SystemRoleFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  public allSelected: Boolean;
  public userRoleForm: FormGroup;
  public systemFearutes: SystemFunctionsModel[] = [];
  public selectedFeatures: SystemFunctionsModel[] = [];
  constructor(private roleApi: SystemRoleApiService,
    private formBuilder: FormBuilder) {
    super();
    this.createForm();
  }

  ngOnInit() {


    this.roleApi.getAllSystemFunctions().subscribe(
      (data: SystemFunctionsModel[]) => this.systemFearutes = data,
      this.handleError
    );
  }

  createForm(): void {
    this.userRoleForm = this.formBuilder.group({
      roleName: ['', Validators.required],
    });
  }

  get roleName(): FormControl {
    return this.userRoleForm.get('roleName') as FormControl;
  }


  onSubmit(): void {
    ;

    const role = this.prepareFormData();
    if (role) {
      this.roleApi.createSystemRole(role).subscribe(
        (data: RoleDetailViewModel) => {
          this.userRoleForm.reset();
          this.notification.showMessage('Role Created Successfully');
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Unable to create user role, pleace try again later');
          this.handleError(error)
        }
      );
    }
  }

  selectAll(): void {
    this.allSelected = !this.allSelected;
    this.systemFearutes.forEach(element => {
      this.featureChecked(element, this.allSelected);
    });
  }


  featureChecked(feature: SystemFunctionsModel, active): void {
    const currentFeature = this.systemFearutes[this.systemFearutes.indexOf(feature)];

    currentFeature.Checked = active;

    currentFeature.Actions.forEach(element => {
      this.actionChecked(currentFeature, element, active);
    });

  }

  actionChecked(feature: SystemFunctionsModel, action: SystemActionsModel, active: boolean) {
    const actionFeature = this.systemFearutes[this.systemFearutes.indexOf(feature)].Actions;
    actionFeature[actionFeature.indexOf(action)].selected = active;
  }

  prepareFormData(): SystemRoleModel | null {

    const roleModel = new SystemRoleModel();
    if (this.userRoleForm.valid) {

      roleModel.name = this.roleName.value;
      const actions = new Array();
      this.systemFearutes.forEach(element => {

        const feature = new SystemFunctionsModel();
        feature.Name = element.Name;
        feature.DisplayName = element.DisplayName;
        feature.Id = element.Id;
        feature.Checked = element.Checked;
        element.Actions.forEach(ele => {
          if (ele.selected) {
            feature.Actions.push(ele);
          }
        });

        actions.push(feature);
      });
      roleModel.access = JSON.stringify(actions);
      return roleModel;
    } else {
      return null;
    }
  }



}
