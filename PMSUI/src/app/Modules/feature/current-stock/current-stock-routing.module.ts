import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CurrentStockViewComponent } from './current-stock-view/current-stock-view.component';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';




const routes: Routes = [
    { path: '', component: CurrentStockViewComponent},
    { path: 'low-stock', component: LowStockViewComponent},
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class StockRoutingModule { }
