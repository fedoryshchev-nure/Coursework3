import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { SensorService } from 'app/admin/services/sensor.service';

import { SensorDTO } from 'app/admin/models/sensor-dto';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  amount = 'Amount';

  successMessages: string[] = [];
  errorMessages: string[] = [];

  sensorDTOs: SensorDTO[] = [];

  amountForm = this.fb.group({
    Amount: ['', [
      Validators.required, 
      Validators.min(1), 
      Validators.max(20)
    ]]
  });

  constructor(
    private fb: FormBuilder,
    private sensorService: SensorService
  ) { }

  ngOnInit() {
  }

  private onAmountFormSubmit(): void {
    if (this.amountForm.valid) {
      this.sensorService.createSensors(
        this.amountForm.controls[this.amount].value).subscribe(dtos => {
          console.log(dtos);
          this.sensorDTOs = dtos;
        }, error => {
          this.errorMessages = [error.message];
        });
    }
  }

}
