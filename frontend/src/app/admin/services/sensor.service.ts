import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

import { SensorDTO } from '../models/sensor-dto';
import { UserWallDTO } from '../models/user-wall-dto';
import { MaterialDTO } from 'app/walls-state/dtos/material-dto';
import { WallDTO } from 'app/walls-state/dtos/wall-dto';
import { CreateWallDTO } from '../models/create-wall-dto';

const headers = new HttpHeaders({
  'Content-Type': 'application/json; charset=utf-8',
});

@Injectable({
  providedIn: 'root'
})
export class SensorService {

  constructor(
    private http: HttpClient
  ) { }

  public createSensors(wallDTO: CreateWallDTO): Observable<SensorDTO[]> {
    return this.http.post<SensorDTO[]>(
      `${environment.apiLink}/admin/createSensors/`,
      wallDTO,
      { headers: headers }
    );
  }

  public attachWallToUser(userWallDTO: UserWallDTO): Observable<any> {
    console.log(userWallDTO);
    return this.http.post(
      `${environment.apiLink}/admin/attachWallToUser`,
      userWallDTO,
      { headers: headers }
    );
  }

  public createMaterial(materialDTO: MaterialDTO) {
    return this.http.post(
      `${environment.apiLink}/admin/CreateMaterial`,
      materialDTO,
      { headers }
    );
  }

  
  public GetMaterials(): Observable<MaterialDTO[]> {
    return this.http.get<MaterialDTO[]>(
      `${environment.apiLink}/admin/GetMaterials`,
      { headers }
    );
  }
}
