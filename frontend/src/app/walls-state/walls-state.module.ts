import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WallsStateRoutingModule } from './walls-state-routing/walls-state-routing.module';

import { MainComponent } from './components/main/main.component';

@NgModule({
  declarations: [MainComponent],
  imports: [
    WallsStateRoutingModule,
    CommonModule
  ]
})
export class WallsStateModule { }
