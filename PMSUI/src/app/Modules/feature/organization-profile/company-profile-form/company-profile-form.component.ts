import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CompanyProfileService } from '../company-profile.service';
import { CustomErrorResponse } from '../../../core/core-api.service';

@Component({
  selector: 'app-company-profile-form',
  templateUrl: './company-profile-form.component.html',
  styleUrls: ['./company-profile-form.component.css']
})
export class CompanyProfileFormComponent implements OnInit {

  public profileForm: FormGroup;
  private profileId: number;

  constructor(private companyProfileService: CompanyProfileService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private location: Location) {
    this.initializeForm();
  }

  ngOnInit() {
    this.profileId = + this.activatedRoute.snapshot.paramMap.get('organizationId');

    this.companyProfileService.getCompanyProfile()
      .subscribe(
        (data: any) => this.initializeForm(data),
        (error: CustomErrorResponse) => console.log(error)
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
          this.location.back();
          alert('Company Profile Updated Successfully');
        },
        (error: CustomErrorResponse) => console.log(error)
      );
  }
}
