import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { JwtModule } from '@auth0/angular-jwt';

import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { SharedModule } from 'app/shared/shared.module';

import { NavbarComponent } from './components/navbar/navbar.component';

export function tokenGetter() {
  return sessionStorage.getItem('jwt');
}

export function httpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, "http://localhost:57660/language/");
}

@NgModule({
  declarations: [NavbarComponent],
  imports: [
    SharedModule,
    CommonModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: httpLoaderFactory,
          deps: [HttpClient]
      }
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:57660']
      }
    })
  ],
  exports: [
    NavbarComponent
  ]
})
export class CoreModule { }
