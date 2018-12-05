import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccessGuard } from '../services/access.guard';

import { AdminComponent } from '../components/admin/admin.component';

const routes: Routes = [
  {
    path: "",
    canActivate: [AccessGuard],
    component: AdminComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
