import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { StorageLocationApiService } from 'src/app/Modules/core/services/storage-location/storage-location-api.service';
import { ActivatedRoute } from '@angular/router';
import { StorageLocationView, StorageLocation } from 'src/app/Modules/core/DataModels/storage-location.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { Location } from '@angular/common';

@Component({
  selector: 'app-storage-location-form',
  templateUrl: './storage-location-form.component.html',
  styleUrls: ['./storage-location-form.component.css']
})
export class StorageLocationFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  public storageForm: FormGroup;
  public isUpdate: Boolean;
  public title: string;
  public submitButtonText: string;
  private storageId: number;
  constructor(private formBuilder: FormBuilder,
    private storageApi: StorageLocationApiService,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    super();
    this.createForm();
  }

  ngOnInit() {
    this.storageId = + this.activatedRoute.snapshot.paramMap.get('storageId');
    this.title = 'Create New Storage Location';
    this.isUpdate = false;
    this.submitButtonText = 'Create';
    if (this.storageId) {
      this.isUpdate = true;
      this.title = `Update Storage Location ${this.storageId}`;

      this.storageApi.getStorageLocationById(this.storageId).subscribe(
        (data: StorageLocationView) => this.initializeForm(data),
        this.handleError
      );
    }

  }


  private createForm(): void {
    this.storageForm = this.formBuilder.group({
      name: ['', Validators.required],
      note: [''],
      active: [true, Validators.required]
    });
  }

  private initializeForm(storage: StorageLocationView): void {
    this.storageForm = this.formBuilder.group({
      id: [storage.id],
      name: [storage.name, Validators.required],
      note: [storage.note],
      active: [storage.active, Validators.required]
    });
  }


  get name(): FormControl {
    return this.storageForm.get('name') as FormControl;
  }

  get note(): FormControl {
    return this.storageForm.get('note') as FormControl;
  }

  get active(): FormControl {
    return this.storageForm.get('active') as FormControl;
  }

  onSubmit(): void {
    const storage = this.prepareFormData();
    if (this.isUpdate && storage) {
      this.storageApi.updateStorageLocation(storage).subscribe(
        () => this.notification.showMessage('Storage Location Updated!'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed While Updating Storage Location Try Again', 'error');
          this.handleError(error);
        }
      );
    } else if (storage) {
      this.storageApi.createStorageLocation(storage).subscribe(
        () => {
          this.notification.showMessage('Storage Location Created!');
          this.storageForm.reset();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed While Creating Storage Location Try Again', 'error');
          this.handleError(error);
        }
      );

    }
  }

  deleteStorageLocation(): void {

    if (this.isUpdate && this.storageId) {
      this.storageApi.deleteStorageLocation(this.storageId).subscribe(
        () => {
          this.notification.showMessage('Storage location deleted successfully');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed while attempting to delete storage location, try again later!', 'error');
          this.handleError(error);
        }
      );
    }
  }

  prepareFormData(): StorageLocation {

    if (this.storageForm.valid) {
      const storage = new StorageLocation();
      const formData = this.storageForm.value;

      if (this.storageId) {
        storage.id = this.storageId;
      }
      storage.name = formData.name;
      storage.note = formData.note;
      storage.active = formData.active;

      return storage;
    } else {
      return null;
    }
  }

}
