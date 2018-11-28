import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";

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
    path: '', 
    redirectTo: 'state', 
    pathMatch: 'full'
  },
  { 
    path: '**', 
    redirectTo: 'state', 
    pathMatch: 'full' 
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }