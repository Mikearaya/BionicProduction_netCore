import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { WorkStationApiService } from 'src/app/Modules/core/services/work-station/work-station-api.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { WorkstationGroupView, WorkstationGroup } from 'src/app/Modules/core/DataModels/workstation.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { Browser } from '@syncfusion/ej2-base/src/browser';

@Component({
  selector: 'app-work-station-group-form',
  templateUrl: './work-station-group-form.component.html',
  styleUrls: ['./work-station-group-form.component.css']
})
export class WorkStationGroupFormComponent extends CommonProperties implements OnInit  {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public workstationGroupForm: FormGroup;
  private workstationGroupId: number;
  public isUpdate: Boolean;
  public title: string;
  public submitButtonText: string;
  _value = '#1de4d7';

  constructor(private workstationApi: WorkStationApiService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) {

    super();
    this.createForm();
  }

  ngOnInit() {
    this.workstationGroupId = + this.activatedRoute.snapshot.paramMap.get('workstationGroupId');

    if (this.workstationGroupId) {
      this.isUpdate = true;
      this.title = `Update Workstation Group ${this.workstationGroupId}`;
      this.submitButtonText = 'Update';
      this.workstationApi.getWorkStationGroupById(this.workstationGroupId).subscribe(
        (data: WorkstationGroupView) => this.initializeForm(data),
        this.handleError
      );
    } else {
      this.isUpdate = false;
      this.title = `Create New Workstation Group`;
      this.submitButtonText = 'Create';
    }

  }

  createForm(): void {
    this.workstationGroupForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: [''],
      isActive: [true, Validators.required],
      color: ['']
    });
  }

  initializeForm(data: WorkstationGroupView): void {

    this.workstationGroupForm = this.formBuilder.group({
      name: [data.name, Validators.required],
      description: [data.description],
      isActive: [data.active, Validators.required],
      color: ['']
    });
  }



  get value(): string {
    if (Browser.info.name === 'msie' && this._value.length > 7) {
      return this._value.substring(0, this._value.length - 2);
    } else {
      return this._value;
    }
  }

  @Input('value')
  set value(value: string) {
    this._value = value;
  }
  get name(): FormControl {
    return this.workstationGroupForm.get('name') as FormControl;
  }

  get description(): FormControl {
    return this.workstationGroupForm.get('description') as FormControl;
  }

  get isActive(): FormControl {
    return this.workstationGroupForm.get('isActive') as FormControl;
  }

  get color(): FormControl {
    return this.workstationGroupForm.get('color') as FormControl;
  }

  onSubmit(): void {
    const workstationGroup = this.prepareFormData();
    if (this.isUpdate && workstationGroup != null) {

      this.workstationApi.updateWorkstationGroup(workstationGroup).subscribe(
        () => {
          this.notification.showMessage('Workstation Group Updated ');
          this.workstationGroupForm.reset();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed Updating Workstation', 'error');
          this.handleError(error);
        }
      );
    } else if (workstationGroup != null) {
      this.workstationApi.createWorkstationGroup(workstationGroup).subscribe(
        () => {
          this.notification.showMessage('Workstation Group Created ');
          this.workstationGroupForm.reset();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed While Creating Workstation', 'error');
          this.handleError(error);
        }
      );
    }

  }

  private prepareFormData(): WorkstationGroup {
    if (this.workstationGroupForm.valid) {

      const formData = this.workstationGroupForm.value;
      const workstationGroup = new WorkstationGroup();

      if (this.workstationGroupId && this.isUpdate) {
        workstationGroup.id = this.workstationGroupId;
      }

      workstationGroup.name = formData.name;
      workstationGroup.description = formData.description;
      workstationGroup.active = formData.isActive;

      return workstationGroup;
    } else {
      return null;
    }

  }

}
