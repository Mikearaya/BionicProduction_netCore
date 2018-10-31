import { Component, OnInit } from '@angular/core';
import { CompanyProfileService } from '../company-profile.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomErrorResponse } from '../../../core/core-api.service';

@Component({
  selector: 'app-company-profile-view',
  templateUrl: './company-profile-view.component.html',
  styleUrls: ['./company-profile-view.component.css']
})
export class CompanyProfileViewComponent implements OnInit {
public company: any;
  constructor(private companyProfileService: CompanyProfileService,
            private router: Router ) { }

  ngOnInit() {
    this.companyProfileService.getCompanyProfile().subscribe(
      (data: any) => this.company = data,
      (error: CustomErrorResponse) => console.log(error)
    );
  }

  editProfile() {
    this.router.navigate([`profile/${this.company.id}/edit`]);
  }

}
