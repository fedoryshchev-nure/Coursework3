import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from '../components/main/main.component';
import { WallsDataComponent } from '../components/walls-data/walls-data.component';
import { StatisticsComponent } from '../components/statistics/statistics.component';
import { AutomatComponent } from '../components/automat/automat.component';
import { IotComponent } from '../components/iot/iot.component';

const routes: Routes = [
  {
    path: "",
    component: MainComponent
  },
  {
    path: "data",
    component: WallsDataComponent
  },
  {
    path: "statistics",
    component: StatisticsComponent
  },
  {
    path: "automatization",
    component: AutomatComponent
  },
  {
    path: "iot",
    component: IotComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class WallsStateRoutingModule { }
