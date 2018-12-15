import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { WorkStationApiService } from 'src/app/Modules/core/services/work-station/work-station-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { WorkstationView, Workstation, WorkstationGroupView } from 'src/app/Modules/core/DataModels/workstation.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';

@Component({
  selector: 'app-work-station-form',
  templateUrl: './work-station-form.component.html',
  styleUrls: ['./work-station-form.component.css']
})

export class WorkStationFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  public notification: NotificationComponent;
  public workstationForm: FormGroup;
  public title: string;
  public submitButtontext: string;
  public workstationGroupList: WorkstationGroupView[] = [];
  public workstationGroupFields: { text: string, value: string };
  public isUpdate: Boolean;

  private workstationId: number;

  constructor(private formBuilder: FormBuilder,
    private workstationApi: WorkStationApiService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    super();
    this.createForm();
    this.workstationGroupFields = { text: 'name', value: 'id' };
  }

  ngOnInit() {

    this.workstationId = + this.activatedRoute.snapshot.paramMap.get('workstationId');

    if (this.workstationId) {
      this.isUpdate = true;
      this.title = `Update Workstation ${this.workstationId}`;
      this.submitButtontext = 'Update';

      this.workstationApi.getWorkStationById(this.workstationId).subscribe(
        (data) => this.initializeForm(data),
        this.handleError
      );
    } else {
      this.title = 'Create Workstation';
      this.isUpdate = false;
      this.submitButtontext = 'Create';

    }

    this.workstationApi.getWorkStationGroups().subscribe(
      (data: WorkstationGroupView[]) => this.workstationGroupList = data,
      (error: CustomErrorResponse) => this.handleError
    );


  }

  createForm(): void {
    this.workstationForm = this.formBuilder.group({
      name: ['', Validators.required],
      groupId: ['', Validators.required],
      hourlyRate: [''],
      productivity: [''],
      maintainanceHours: [''],
      maintainanceItems: [''],
      workingHours: [''],
      workingWeek: [''],
      holidayHours: [''],
      isActive: [true, Validators.required]
    });
  }

  initializeForm(data: WorkstationView): void {
    this.workstationForm = this.formBuilder.group({
      name: [data.title, Validators.required],
      groupId: [data.groupId, Validators.required],
      hourlyRate: [data.hourlyRate],
      productivity: [data.productivity],
      maintainanceHours: [data.maintenanceHours],
      maintainanceItems: [data.maintenanceItems],
      workingHours: [data.workingHours],
      holidayHours: [data.holidayHours],
      isActive: [data.isActive, Validators.required]
    });

  }

  createWorkstationGroup(): void {
    this.router.navigate([`work-stations/new`]);
  }

  get name(): FormControl {
    return this.workstationForm.get('name') as FormControl;
  }
  get groupId(): FormControl {
    return this.workstationForm.get('groupId') as FormControl;
  }

  get hourlyRate(): FormControl {
    return this.workstationForm.get('hourlyRate') as FormControl;
  }

  get productivity(): FormControl {
    return this.workstationForm.get('productivity') as FormControl;
  }

  get maintainanceHours(): FormControl {
    return this.workstationForm.get('maintainanceHours') as FormControl;
  }

  get maintainanceItems(): FormControl {
    return this.workstationForm.get('maintainanceItems') as FormControl;
  }

  get workingHours(): FormControl {
    return this.workstationForm.get('workingHours') as FormControl;
  }
  get holidayHours(): FormControl {
    return this.workstationForm.get('holidayHours') as FormControl;
  }

  get isActive(): FormControl {
    return this.workstationForm.get('isActive') as FormControl;
  }

  onSubmit(): void {
    if (this.workstationForm.valid) {
      const workstation = this.prepareFormData();
      if (this.isUpdate && workstation) {
        this.workstationApi.updateWorkstation(workstation).subscribe(
          () => {
            this.notification.showMessage('Workstation Updated');
            this.workstationForm.reset();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unable to Update Workstation try Again', 'error');
          }
        );

      } else if (workstation) {
        this.workstationApi.createWorkstation(workstation).subscribe(
          () => {
            this.notification.showMessage('Workstation Created');
            this.workstationForm.reset();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unable to Create Workstation try Again', 'error');
          }
        );
      }
    }
  }

  private prepareFormData(): Workstation {

    if (this.workstationForm.valid) {
      const formData = this.workstationForm.value;
      const workstation = new Workstation();

      workstation.id = 0;
      if (this.workstationId && this.isUpdate) {
        workstation.id = this.workstationId;
      }

      workstation.Title = formData.name;
      workstation.groupId = formData.groupId;
      workstation.isActive = formData.isActive;
      workstation.holidayHours = formData.holidayHours;
      workstation.maintenanceHours = formData.maintainanceHours;
      workstation.maintenanceItems = formData.maintainanceItems;
      workstation.holidayHours = formData.holidayHours;
      workstation.productivity = formData.productivity;

      return workstation;
    } else {
      return null;
    }

  }

}

