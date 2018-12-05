import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { SensorService } from 'app/admin/services/sensor.service';

import { SensorDTO } from 'app/admin/models/sensor-dto';
import { UserWallDTO } from 'app/admin/models/user-wall-dto';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  amount = 'Amount';
  email = "Email";
  wallId = "WallId";

  sensorDTOs: SensorDTO[] = [];

  errorOccurd = false;

  amountForm = this.fb.group({
    Amount: ['', [
      Validators.required, 
      Validators.min(1), 
      Validators.max(20)
    ]]
  });

  wallToUserForm = this.fb.group({
    Email: ['', Validators.required],
    WallId: ['', Validators.required] 
  });

  constructor(
    private fb: FormBuilder,
    private sensorService: SensorService
  ) { }

  ngOnInit() {
  }

  public onAmountFormSubmit(): void {
    if (this.amountForm.valid) {
      this.sensorService.createSensors(
        this.amountForm.controls[this.amount].value).subscribe(dtos => {
          console.log(dtos);
          this.sensorDTOs = dtos;
        }, error => {
          this.errorOccurd = true;
        });
    }
  }

  public onWallToUserFormSubmit(): void {
    if (this.wallToUserForm.valid){
      this.sensorService.attachWallToUser(
        new UserWallDTO(
          this.wallToUserForm.controls[this.email].value,
          this.wallToUserForm.controls[this.wallId].value)
        ).subscribe(x => {
          //Empty return on success
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

}
