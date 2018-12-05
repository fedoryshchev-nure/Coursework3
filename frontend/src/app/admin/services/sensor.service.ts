import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment';

import { SensorDTO } from '../models/sensor-dto';
import { UserWallDTO } from '../models/user-wall-dto';

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

  public createSensors(amount: number): Observable<SensorDTO[]> {
    return this.http.get<SensorDTO[]>(
      `${environment.apiLink}/admin/createSensors/${amount}`,
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
}
