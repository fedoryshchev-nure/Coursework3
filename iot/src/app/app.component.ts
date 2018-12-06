import { Component } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';

import { ApiCallService } from './api-call.service';
import { SensortDto } from './sensor-dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'iot';

  iotForm = this.fb.group({
    Id: ['', Validators.required],
    Password: ['', Validators.required],
    IsBroken: [false, Validators.required]
  });

  constructor(
    private fb: FormBuilder,
    private apiCallService: ApiCallService
  ) {}

  public onSubmit(): void {
    this.apiCallService.ping(
      new SensortDto(
        this.iotForm.controls['Id'].value,
        this.iotForm.controls['Password'].value,
        this.iotForm.controls['IsBroken'].value
      ) 
    ).subscribe(x => {}, 
      err => {
        console.log(err);
    });
  }
}
