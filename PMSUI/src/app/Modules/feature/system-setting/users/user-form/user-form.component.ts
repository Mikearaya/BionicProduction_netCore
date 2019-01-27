import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { UserApiService } from 'src/app/Modules/core/services/users/user-api.service';
import { SystemRoleApiService } from '../../services/system-role-api.service';
import { ActivatedRoute } from '@angular/router';
import { UserViewModel, UserModel } from 'src/app/Modules/core/DataModels/user.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Location } from '@angular/common';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  public notification: NotificationComponent;

  public isUpdate: Boolean;
  public userForm: FormGroup;
  public rolesList: any[] = [];
  private userId: string;

  public roleFields: { text: string, value: string };

  constructor(
    private userApi: UserApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private roleApi: SystemRoleApiService
  ) {
    super();
    this.usersForm();
    this.roleFields = { text: 'name', value: 'id' };
  }

  ngOnInit(): void {
    // get user is from route parameter if it exists
    this.userId = this.activatedRoute.snapshot.paramMap.get('userId');
    this.isUpdate = false;
    if (this.userId) { // if user id exist get value and initialize form
      this.isUpdate = true;
      this.userApi.getUserById(this.userId).subscribe(
        (user: UserViewModel) => this.initilizeForm(user)
      );
    }


    this.roleApi.getAllSystemRoles().subscribe(
      data => this.rolesList = data,
      this.handleError
    );
  }

  // ─── INTIALIZING USERS FORM ─────────────
  usersForm(): void {
    this.userForm = this.formBuilder.group({
      id: [''],
      userName: ['', Validators.required],
      roleId: ['', Validators.required]
    });
  }

  initilizeForm(user: UserViewModel): void {

    this.userForm = this.formBuilder.group({
      id: [user.id, Validators.required],
      firstName: [user.userName, Validators.required],
      roleId: [user.roleId, Validators.required]
    });

  }

  get userName(): FormControl {
    return this.userForm.get('userName') as FormControl;
  }

  get roleId(): FormControl {
    return this.userForm.get('roleId') as FormControl;
  }


  private prepareFormData(): UserModel | null {

    let userData: UserModel;

    if (this.userForm.valid) {
      userData = {
        id: this.userId ? this.userId : '',
        userName: this.userName.value,
        roleId: this.roleId.value
      };
      return userData;
    }

    return null;
  }

  onSubmit(): void {

    const data = this.prepareFormData();

    if (data) {
      if (this.userId && data != null) {

        this.userApi.updateUser(data).subscribe(
          () => {
            this.notification.showMessage('User Updated Successfuly!!!');
            this.userForm.reset();
          }, (error: CustomErrorResponse) => {
            this.notification.showMessage('Error Occured while attempting to create user try again later!!!', 'error');
            this.handleError(error);
          }
        );
      } else {
        this.userApi.createUser(data).subscribe(
          () => {
            this.notification.showMessage('User Created Successfuly!!!');
            this.userForm.reset();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Unknown Error Occured while updating user data, try again later');
            this.handleError(error);
          });
      }

    }

  }

  onDelete(): void {
    if (this.userId) {
      this.userApi.deleteUser(this.userId).subscribe(
        () => {
          this.notification.showMessage('User Deleted successfuly');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Unable to delete user, please try again later');
          this.handleError(error);
        }
      );
    }
  }
}
