import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceMainComponent } from 'src/app/components/invoice-main/invoice-main.component';
import { InvoiceComponent } from 'src/app/components/invoice/invoice.component';

const routes: Routes = [
  {
    path: '', component: InvoiceMainComponent,
    children: [
      { path: '', component: InvoiceComponent },
      { path: 'invoice', component: InvoiceComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }
