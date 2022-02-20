import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/shared.module';
import { InvoiceRoutingModule } from './invoice-routing.module';

import { InvoiceMainComponent } from 'src/app/components/invoice-main/invoice-main.component';
import { InvoiceComponent } from 'src/app/components/invoice/invoice.component';


@NgModule({
  declarations: [
    InvoiceMainComponent,
    InvoiceComponent
  ],
  imports: [
    CommonModule,
    InvoiceRoutingModule,
    SharedModule,
    
  ],
  providers:[]
})
export class InvoiceModule { }
