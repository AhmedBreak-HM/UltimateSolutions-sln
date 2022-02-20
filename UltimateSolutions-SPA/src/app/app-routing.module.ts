import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './services/guards/auth.guard';

const routes: Routes = [
  { path: '', loadChildren: () => import('./layouts/auth/auth.module').then(m => m.AuthModule) },
  { path: 'auth', loadChildren: () => import('./layouts/auth/auth.module').then(m => m.AuthModule) },
  { path: 'invoice',canLoad:[AuthGuard], loadChildren: () => import('./layouts/invoice/invoice.module').then(m => m.InvoiceModule) },
  { path: 'admin',canLoad:[AuthGuard], loadChildren: () => import('./layouts/admin/admin.module').then(m => m.AdminModule) },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
