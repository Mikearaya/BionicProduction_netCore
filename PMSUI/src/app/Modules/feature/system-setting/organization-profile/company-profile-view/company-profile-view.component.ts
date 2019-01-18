import { Component, OnInit, ViewChild } from '@angular/core';
import { CompanyProfileService } from '../company-profile.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';


@Component({
  selector: 'app-company-profile-view',
  templateUrl: './company-profile-view.component.html',
  styleUrls: ['./company-profile-view.component.css']
})
export class CompanyProfileViewComponent extends CommonProperties implements OnInit {
  public company: any;
  @ViewChild('notification') notitfication: NotificationComponent;

  constructor(private companyProfileService: CompanyProfileService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit() {
    this.companyProfileService.getCompanyProfile().subscribe(
      (data: any) => this.company = data,
      this.handleError
    );
  }

  editProfile() {
    this.router.navigate([`${this.company.id}/update`], { relativeTo: this.activatedRoute });
  }

}
