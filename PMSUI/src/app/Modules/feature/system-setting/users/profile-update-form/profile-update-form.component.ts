import { Component, OnInit, ViewChild } from '@angular/core';
import { UserApiService } from 'src/app/Modules/core/services/users/user-api.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserViewModel, UpdatedUserModel } from 'src/app/Modules/core/DataModels/user.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';

@Component({
  selector: 'app-profile-update-form',
  templateUrl: './profile-update-form.component.html',
  styleUrls: ['./profile-update-form.component.css']
})
export class ProfileUpdateFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public userProfileForm: FormGroup;
  private userId: string;

  constructor(private userApi: UserApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute) {
    super();
    this.createForm();
  }

  ngOnInit() {

    this.userId = this.activatedRoute.snapshot.paramMap.get('userId');

    if (this.userId) {
      this.userApi.getUserById(this.userId).subscribe(
        (data: UserViewModel) => this.initializeForm(data),
        this.handleError
      );
    }
  }


  createForm(): void {
    this.userProfileForm = this.formBuilder.group({
      userName: ['', Validators.required],
      fullName: [''],
      email: ['', Validators.email],
      phoneNumber: [''],
      roleId: ['']
    });
  }

  initializeForm(user: UserViewModel): void {
    this.userProfileForm = this.formBuilder.group({
      userName: [user.userName, Validators.required],
      fullName: [],
      email: ['', Validators.email],
      phoneNumber: [''],
      roleId: ['']
    });
  }


  get userName(): FormControl {
    return this.userProfileForm.get('userName') as FormControl;
  }

  get fullName(): FormControl {
    return this.userProfileForm.get('fullName') as FormControl;
  }

  get email(): FormControl {
    return this.userProfileForm.get('email') as FormControl;
  }

  get phoneNumber(): FormControl {
    return this.userProfileForm.get('phoneNumber') as FormControl;
  }

  get roleId(): FormControl {
    return this.userProfileForm.get('roleId') as FormControl;
  }


  onSubmit(): void {
    const formData = this.prepareFormData();

    if (formData) {
      this.userApi.updateUser(formData).subscribe(
        () => this.notification.showMessage('Profile updated successfuly'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed while attemptin to update profile, Try again later');
          this.handleError(error);
        }
      );
    }
  }

  private prepareFormData(): UpdatedUserModel | null {

    if (this.userProfileForm.valid) {
      return {
        id: this.userId,
        userName: this.userName.value,
        fullName: this.fullName.value,
        email: this.email.value,
        phoneNumber: this.phoneNumber.value,
        roleId: this.roleId.value
      };
    } else {
      return null;
    }
  }




}
