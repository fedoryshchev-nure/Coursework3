import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorsComponent } from './messages/errors/errors.component';
import { SuccessComponent } from './messages/success/success.component';
import { WarningComponent } from './messages/warning/warning.component';

@NgModule({
  declarations: [
    ErrorsComponent, 
    SuccessComponent, 
    WarningComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ErrorsComponent, 
    SuccessComponent, 
    WarningComponent
  ]
})
export class SharedModule { }
