import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { SensortDto } from './sensor-dto';

const headers = new HttpHeaders({
  'Content-Type': 'application/json; charset=utf-8',
});

@Injectable({
  providedIn: 'root'
})
export class ApiCallService {

  constructor(
    private http: HttpClient,
  ) { }

  public ping(sensordDto: SensortDto): Observable<any> {
    return this.http.post(
      `http://localhost:57660/sensor`,
      sensordDto,
      { headers: headers }
    );
  }
}
