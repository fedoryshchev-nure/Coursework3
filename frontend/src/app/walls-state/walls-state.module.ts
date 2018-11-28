import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WallsStateRoutingModule } from './walls-state-routing/walls-state-routing.module';

import { SharedModule } from 'app/shared/shared.module';

import { MainComponent } from './components/main/main.component';

@NgModule({
  declarations: [MainComponent],
  imports: [
    WallsStateRoutingModule,
    SharedModule,
    CommonModule
  ]
})
export class WallsStateModule { }
