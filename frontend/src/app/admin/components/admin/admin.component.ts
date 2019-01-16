import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { SensorService } from 'app/admin/services/sensor.service';

import { SensorDTO } from 'app/admin/models/sensor-dto';
import { UserWallDTO } from 'app/admin/models/user-wall-dto';
import { QueryService } from 'app/walls-state/services/query.service';
import { MaterialDTO } from 'app/walls-state/dtos/material-dto';
import { WallDTO } from 'app/walls-state/dtos/wall-dto';
import { CreateWallDTO } from 'app/admin/models/create-wall-dto';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  materialFormSelected = true;
  admountFormSelected = false;
  attachFormSelected = false;

  amount = 'Amount';
  material = 'Name';
  email = "Email";
  wallId = "WallId";

  sensorDTOs: SensorDTO[] = [];
  materials: MaterialDTO[] = [];

  selectedMaterail = "";

  errorOccurd = false;

  materialForm = this.fb.group({
    Name: ['', [
      Validators.required, 
      Validators.min(1), 
      Validators.max(20)
    ]]
  });

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
    private sensorService: SensorService,
    private queryService: QueryService
  ) { }

  ngOnInit() {
    this.sensorService.GetMaterials().subscribe(x => {
      this.materials = x;
      this.selectedMaterail = x[0].id;
    })
  }

  public onAmountFormSubmit(): void {
    if (this.amountForm.valid) {
      this.sensorService.createSensors(
        new CreateWallDTO(
          this.amountForm.controls[this.amount].value,
          new MaterialDTO(this.selectedMaterail, "")
        )).subscribe(dtos => {
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
          // Empty return on success
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

  public onMaterialFormSubmit(id: string): void {
    if (this.materialForm.valid) {
      this.sensorService.createMaterial(
        new MaterialDTO(
          id,
          this.materialForm.controls[this.material].value)
      ).subscribe(x => {
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

  private setSelectedMaterial(materialId: string) {
   this.selectedMaterail = materialId; 
  }

  private materialFormSelectedClick(): void {
    this.materialFormSelected = true;
    this.admountFormSelected = false;
    this.attachFormSelected = false;
  }

  private admountFormSelectedClick(): void {
    this.materialFormSelected = false;
    this.admountFormSelected = true;
    this.attachFormSelected = false;
    this.sensorService.GetMaterials().subscribe(x => {
      this.materials = x;
      this.selectedMaterail = x[0].id;
    })
  }

  private attachFormSelectedClick(): void {
    this.materialFormSelected = false;
    this.admountFormSelected = false;
    this.attachFormSelected = true;
  }
}
