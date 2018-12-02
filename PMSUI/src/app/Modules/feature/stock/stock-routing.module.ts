import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';
import { StockViewComponent } from './stock-view/stock-view.component';
import { StockFormComponent } from './stock-form/stock-form.component';
import { ProductGroupViewComponent } from './product-group-view/product-group-view.component';
import { ProductGroupFormComponent } from './product-group-form/product-group-form.component';




const routes: Routes = [
  { path: '', component: StockViewComponent },
  { path: 'low-stock', component: LowStockViewComponent },
  { path: 'item', component: StockFormComponent },
  { path: 'item/:itemId', component: StockFormComponent },
  { path: 'product-groups', component: ProductGroupViewComponent },
  { path: 'product-groups/new', component: ProductGroupFormComponent },
  { path: 'product-groups/:groupId/update', component: ProductGroupFormComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockRoutingModule { }
