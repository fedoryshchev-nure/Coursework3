import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'environments/environment';

import { Observable } from 'rxjs';
import { WallDTO } from '../dtos/wall-dto';

const headers = new HttpHeaders({
  'Content-Type': 'application/json; charset=utf-8',
});

@Injectable({
  providedIn: 'root'
})
export class QueryService {

  constructor(
    private http: HttpClient
  ) { }

  public GetWallsWithSensorForUser(): Observable<WallDTO[]> {
    return this.http.get<WallDTO[]>(
      `${environment.apiLink}/query/GetWallsWithSensorForUser`,
      { headers }
    );
  }

  public GetRegionsOrderedByWallDamage(): Observable<string[]> {
    return this.http.get<string[]>(
      `${environment.apiLink}/query/GetRegionsOrderedByWallDamage`,
      { headers }
    );
  }

  public GetMostDamagedMaterials(): Observable<string[]> {
    return this.http.get<string[]>(
      `${environment.apiLink}/query/GetMostDamagedMaterials`,
      { headers }
    );
  }

  public GetBestMaterials(): Observable<string[]> {
    return this.http.get<string[]>(
      `${environment.apiLink}/query/GetBestMaterials`,
      { headers }
    );
  }

  public GetBestRegions(): Observable<string[]> {
    return this.http.get<string[]>(
      `${environment.apiLink}/query/GetBestRegions`,
      { headers }
    );
  }
}
