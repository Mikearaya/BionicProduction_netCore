import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserApiService } from 'src/app/Modules/core/services/users/user-api.service';
import { PasswordChangeModel } from 'src/app/Modules/core/DataModels/user.model';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';

@Component({
  selector: 'app-password-change-form',
  templateUrl: './password-change-form.component.html',
  styleUrls: ['./password-change-form.component.css']
})
export class PasswordChangeFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  private userId: string;
  public passwordChangeForm: FormGroup;

  constructor(private userApi: UserApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute) {
    super();
    this.createForm();
  }


  ngOnInit() {
    this.userId = this.activatedRoute.snapshot.paramMap.get('userId');
  }

  private createForm(): void {
    this.passwordChangeForm = this.formBuilder.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', Validators.required],
      confirmedPassword: ['', Validators.required]
    });
  }

  get currentPassword(): FormControl {
    return this.passwordChangeForm.get('currentPassword') as FormControl;
  }

  get newPassword(): FormControl {
    return this.passwordChangeForm.get('newPassword') as FormControl;
  }

  get confirmedPassword(): FormControl {
    return this.passwordChangeForm.get('confirmedPassword') as FormControl;
  }

  onSubmit(): void {
    const formData = this.prepareFormData();

    if (formData) {
      this.userApi.updateUserPassword(formData).subscribe(
        () => {
          this.notification.showMessage('Password updated successfuly');
          this.passwordChangeForm.reset();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage(error.message, 'error');
          this.handleError(error);
        }
      );
    } else {
      this.notification.showMessage('One or more required fields missing', 'error');
    }
  }

  private prepareFormData(): PasswordChangeModel {

    if (this.passwordChangeForm.valid) {
      return {
        id: this.userId,
        currentPassword: this.currentPassword.value,
        newPassword: this.newPassword.value,
        confirmedPassword: this.confirmedPassword.value
      };
    } else {
      return null;
    }
  }
}
