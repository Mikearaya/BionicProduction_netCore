import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CompanyProfileService } from '../company-profile.service';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';

@Component({
  selector: 'app-company-profile-form',
  templateUrl: './company-profile-form.component.html',
  styleUrls: ['./company-profile-form.component.css']
})
export class CompanyProfileFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  private notification: NotificationComponent;
  public profileForm: FormGroup;
  private profileId: number;

  constructor(private companyProfileService: CompanyProfileService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private location: Location) {

    super();
    this.initializeForm();
  }

  ngOnInit() {
    this.profileId = + this.activatedRoute.snapshot.paramMap.get('organizationId');

    this.companyProfileService.getCompanyProfile()
      .subscribe(
        (data: any) => this.initializeForm(data),
        this.handleError
      );

  }


  createForm(): void {
    this.profileForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      tin: ['', Validators.required],
      country: [''],
      city: [''],
      subCity: [''],
      location: ['']
    });
  }

  initializeForm(data: any = ''): void {
    this.profileForm = this.formBuilder.group({
      id: [data.id, Validators.required],
      name: [data.name, Validators.required],
      tin: [data.tin, Validators.required],
      country: [data.country],
      city: [data.city],
      subCity: [data.subCity],
      location: [data.location]
    });
  }

  onSubmit() {
    const form = this.profileForm.value;

    this.companyProfileService.updateCompanyProfile(this.profileId, form)
      .subscribe(
        (data: boolean) => {
          this.notification.showMessage('Profile Updated', 'success');
          this.location.back();

        },
        this.handleError
      );
  }
}
