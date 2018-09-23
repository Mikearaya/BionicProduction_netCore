import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormArray } from '@angular/forms';
import { FinishedProductsApiService, FinishedProductsView } from '../finished-products-api.service';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { Query, WebApiAdaptor, DataManager, ReturnOption } from '@syncfusion/ej2-data';
import { Location } from '@angular/common';

@Component({
    selector: 'app-finished-product-form',
    templateUrl: './finished-product-form.component.html',
    styleUrls: ['./finished-product-form.component.css']
})
export class FinishedProductFormComponent implements OnInit {

    public finishedProductsForm: FormGroup;
    public employeeQuery: Query;
    public employeeFields: Object;
    public orderQuery: Query;
    public orderFields: Object;
    public employeeList: any[];
    public orderList: any[];

    constructor(private formBuilder: FormBuilder,
        private finishedProductsApi: FinishedProductsApiService,
        private activatedRoute: ActivatedRoute,
        private location: Location) {

        this.employeeQuery = new Query().select(['firstName', 'id']);
        this.employeeFields = { text: 'firstName', value: 'id' };
        this.orderQuery = new Query().select(['orderId']);
        this.orderFields = { text: 'orderId', value: 'orderId' };
        this.createForm();
    }

    ngOnInit() {
        const employee: DataManager = new DataManager(
            { url: 'http://localhost:5000/api/employees', adaptor: new WebApiAdaptor, offline: true },
            new Query().take(8)
        );
        employee.ready.then((e: ReturnOption) => this.employeeList = <Object[]>e.result).catch((e) => true);

        const order: DataManager = new DataManager(
            { url: 'http://localhost:5000/api/workorders', adaptor: new WebApiAdaptor, offline: true },
            new Query().take(8)
        );

        order.ready.then((e: ReturnOption) => this.orderList = <Object[]>e.result).catch((e) => true);

    }

    createForm() {
        this.finishedProductsForm = this.formBuilder.group({
            submitionForm: this.formBuilder.array([
                this.form()
            ])

        });

    }

    form(): FormGroup {
        return this.formBuilder.group({
            orderId: ['', Validators.required],
            quantity: ['', [Validators.required, Validators.min(0)]],
            submitedBy: ['', Validators.required],
            recievedBy: ['', Validators.required]
        });

    }

    get submitionForm(): FormArray {
        return this.finishedProductsForm.get('submitionForm') as FormArray;
    }

    addForm() {
        this.submitionForm.push(this.form());
    }

    onSubmit() {
        const form = this.submitionForm.value;

        this.finishedProductsApi.addFinishedProduct(form).subscribe((success) => {
            console.log(success);
            alert('products saved to inventory successfuly');
            this.location.back();
        },
            (error: HttpErrorResponse) => console.log(error));
    }

}
