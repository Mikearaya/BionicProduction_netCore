import { Component, OnInit, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import { SystemRoleApiService } from '../../services/system-role-api.service';
import { SystemFunctionsModel, SystemRoleModel, SystemActionsModel, RoleDetailViewModel } from '../system-role-data.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { TreeViewComponent } from '@syncfusion/ej2-angular-navigations';
import { NodeClickEventArgs } from '@syncfusion/ej2-angular-navigations';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-system-role-form',
  templateUrl: './system-role-form.component.html',
  styleUrls: ['./system-role-form.component.css']
})
export class SystemRoleFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  @ViewChild('rolesTree')
  rolesTree: TreeViewComponent;

  public allSelected: Boolean;
  public userRoleForm: FormGroup;
  private roleId: string;
  public title: string;
  public isUpdate: Boolean;

  public systemFearutes: SystemFunctionsModel[] = [];
  public selectedFeatures: SystemFunctionsModel[] = [];
  public field: { dataSource: Object[], id: string, text: string, child: string };


  constructor(private roleApi: SystemRoleApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private location: Location) {
    super();

    this.createForm();
  }

  ngOnInit() {
    this.rolesTree.sortOrder = 'Ascending';

    this.roleId = this.activatedRoute.snapshot.paramMap.get('roleId');

    if (this.roleId) {
      this.isUpdate = true;
      this.roleApi.getSystemRoleById(this.roleId).subscribe(
        (data: RoleDetailViewModel) => {
          this.roleName.setValue(data.name);

          this.rolesTree.checkedNodes = JSON.parse(data.access);
          this.rolesTree.refresh();
        }
      );
    }

    this.roleApi.getAllSystemFunctions().subscribe(
      (data: SystemFunctionsModel[]) => this.field = { dataSource: data, id: 'id', text: 'name', child: 'Actions' },
      this.handleError
    );

  }
  public nodeChecked(args): void {
    console.log(`The checked node's id is:  + ${this.rolesTree.checkedNodes}`);

  }

  deleteRole(): void {
    this.roleApi.deleteSystemRole(this.roleId).subscribe(
      () => {
        this.notification.showMessage('Role deleted successfuly');
        this.location.back();
      },
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Failed while attempting to delete system role, Try again later!', 'error');
      }
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


    const role = this.prepareFormData();
    if (role) {
      if (this.isUpdate) {
        this.roleApi.updateSystemRole(role).subscribe(
          () => {
            this.notification.showMessage('Role Updated Successfully');
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unable to update user role, pleace try again later');
            this.handleError(error);
          },
          () => this.rolesTree.collapseAll()
        );

      } else {
        this.roleApi.createSystemRole(role).subscribe(
          (data: RoleDetailViewModel) => {
            this.userRoleForm.reset();
            this.notification.showMessage('Role Created Successfully');
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unable to create user role, pleace try again later');
            this.handleError(error);
          },
          () => this.rolesTree.collapseAll()
        );
      }
    }
  }

  selectAll(): void {
    /*  ;
    this.systemFearutes.forEach(element => {
      this.featureChecked(element, this.allSelected);
    }); */

    this.allSelected = !this.allSelected;
    if (this.allSelected) {
      this.rolesTree.expandAll();
      this.rolesTree.checkAll();
    } else {
      this.rolesTree.uncheckAll();
      this.rolesTree.collapseAll();
    }

  }

  public nodeCheck(args: NodeClickEventArgs): void {
    /*     const checkedNode: any = [args.node];
        if (args.event.target['classList'].contains('e-fullrow')) {
          const getNodeDetails: any = this.rolesTree.getNode(args.node);
          if (getNodeDetails.isChecked === 'true') {
            this.rolesTree.uncheckAll(checkedNode);
          } else {
            this.rolesTree.checkAll(checkedNode);
          }
        } */
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
    this.rolesTree.expandAll();

    const roleModel = new SystemRoleModel();
    if (this.userRoleForm.valid) {
      if (this.isUpdate) {
        roleModel.id = this.roleId;
      }


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
      roleModel.access = JSON.stringify(this.rolesTree.checkedNodes);
      return roleModel;
    } else {
      return null;
    }
  }



}
