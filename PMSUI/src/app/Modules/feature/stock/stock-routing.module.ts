import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';
import { StockViewComponent } from './stock-view/stock-view.component';




const routes: Routes = [
    { path: '', component: StockViewComponent},
    { path: 'low-stock', component: LowStockViewComponent},
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class StockRoutingModule { }
