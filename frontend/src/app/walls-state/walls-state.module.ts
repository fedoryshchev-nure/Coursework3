import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WallsStateRoutingModule } from './walls-state-routing/walls-state-routing.module';

import { SharedModule } from 'app/shared/shared.module';

import { MainComponent } from './components/main/main.component';
import { WallsDataComponent } from './components/walls-data/walls-data.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { AutomatComponent } from './components/automat/automat.component';

@NgModule({
  declarations: [
    MainComponent,
    WallsDataComponent,
    StatisticsComponent,
    AutomatComponent
  ],
  imports: [
    WallsStateRoutingModule,
    SharedModule,
    CommonModule
  ]
})
export class WallsStateModule { }
