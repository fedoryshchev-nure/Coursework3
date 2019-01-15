import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import * as jwtDecode from 'jwt-decode';

import { environment } from 'environments/environment';

import { SignInModel } from 'app/shared/models/account/sign-in-model';
import { SignUpModel } from 'app/shared/models/account/sign-up-model';
import { AuthenticationToken } from 'app/shared/models/account/authentication-token';

const headers = new HttpHeaders({
  'Content-Type': 'application/json; charset=utf-8',
});

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  public signUp(signUpModel: SignUpModel): Observable<any> {
    return this.http.post(
      `${environment.apiLink}/account/register`,
      signUpModel,
      { headers: headers }
    );
  }

  public signIn(signInModel: SignInModel): Observable<AuthenticationToken> {
    return this.http.post<AuthenticationToken>(
      `${environment.apiLink}/account/token`,
      signInModel,
      { headers: headers }
    );
  }

  public isSignedIn(): boolean {
    return !!sessionStorage.getItem('jwt');
  }

  public isAdmin(): boolean {
    let res = false;

    if (this.isSignedIn()) {
      res = (jwtDecode(sessionStorage.getItem('jwt'))
        ['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ==
          "Admin");
    }

    return res;
  }

  public signOut(): void {
    sessionStorage.removeItem('jwt');
    this.router.navigate(['/']);
  }
}