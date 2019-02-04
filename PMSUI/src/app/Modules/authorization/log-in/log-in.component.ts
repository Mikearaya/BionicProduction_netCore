import { Component, OnInit } from '@angular/core';
import { AuthrizationService } from '../authrization.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { LogInModel } from '../authrization.model';
import { CommonProperties } from '../../core/DataModels/common-properties.class';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent extends CommonProperties implements OnInit {
  public logInForm: FormGroup;
  public errorMessage: string;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authorizationService: AuthrizationService) {
    super();
    this.createForm();
  }

  ngOnInit() {
  }

  createForm(): void {
    this.logInForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get userName(): FormControl {
    return this.logInForm.get('userName') as FormControl;
  }

  get password(): FormControl {
    return this.logInForm.get('password') as FormControl;
  }

  onSubmit(): void {
    const logInModel = this.prepareFormData();

    this.authorizationService.login(logInModel).subscribe(
      (data: any) => {
        this.router.navigate(['home']);
      },
      (error) => {
        this.errorMessage = 'Invalid username or password';
      }
    );
  }

  prepareFormData(): LogInModel | null {

    if (this.logInForm.valid) {
      return {
        userName: this.userName.value,
        password: this.password.value
      };
    } else {
      return null;
    }
  }

}
