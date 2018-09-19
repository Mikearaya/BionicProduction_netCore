import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FinishedProductsViewComponent } from './finished-products-view/finished-products-view.component';
import { FinishedProductFormComponent } from './finished-product-form/finished-product-form.component';

const routes: Routes = [
    { path: '', component: FinishedProductsViewComponent },
    { path: 'new', component: FinishedProductFormComponent },
    { path: ':finishedProductId/update', component: FinishedProductFormComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FinishedProductsRoutingModule { }
