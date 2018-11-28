import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'environments/environment.prod';

import { SignInModel } from '../models/sign-in-model';
import { SignUpModel } from '../models/sign-up-model';
import { AuthenticationToken } from '../models/authentication-token';

const headers = new HttpHeaders({
  'Content-Type': 'application/json; charset=utf-8',
});

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(
    private http: HttpClient
  ) { }

  public signIn(signInModel: SignInModel): Observable<AuthenticationToken> {
    return this.http.post<AuthenticationToken>(
      `${environment.apiLink}/account/token`,
      signInModel,
      { headers: headers }
    );
  }

  public signUp(signUpModel: SignUpModel): Observable<any> {
    return this.http.post(
      `${environment.apiLink}/account/register`,
      signUpModel,
      { headers: headers }
    );
  }
}
