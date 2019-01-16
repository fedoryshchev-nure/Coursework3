import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';

import { ApiCallService } from 'app/walls-state/services/api-call.service';
import { SensortDto } from 'app/walls-state/dtos/sensor-dto';

@Component({
  selector: 'app-iot',
  templateUrl: './iot.component.html',
  styleUrls: ['./iot.component.css']
})
export class IotComponent implements OnInit {
  title = 'iot';

  iotForm = this.fb.group({
    Id: ['', Validators.required],
    Password: ['', Validators.required],
    IsBroken: [0, Validators.required]
  });

  constructor(
    private fb: FormBuilder,
    private apiCallService: ApiCallService
  ) {}

  ngOnInit() {
    
  }

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