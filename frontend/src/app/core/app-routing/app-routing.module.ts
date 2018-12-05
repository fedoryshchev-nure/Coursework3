import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";

import { NotFoundComponent } from 'app/shared/not-found/not-found.component';

const routes: Routes = [
  {
    path: "account",
    loadChildren: "app/account/account.module#AccountModule"
  },
  {
    path: "state",
    loadChildren: "app/walls-state/walls-state.module#WallsStateModule"
  },
  {
    path: "admin",
    loadChildren: "app/admin/admin.module#AdminModule"
  },
  { 
    path: '', 
    redirectTo: 'state', 
    pathMatch: 'full'
  },
  { 
    path: '**', 
    pathMatch: 'full',
    component: NotFoundComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }