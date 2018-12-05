import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormBuilder, Validators } from '@angular/forms';

import { AuthService } from 'app/core/services/auth.service';

import { SignInModel } from 'app/shared/models/account/sign-in-model';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  email = 'Email';
  password = 'Password';

  errorOccurd = false;

  signInForm = this.fb.group({
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]]
  });

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
  }

  private onSubmit(): void {
    if (this.signInForm.valid) {
      const signInModel = new SignInModel(
        this.signInForm.controls['Email'].value,
        this.signInForm.controls['Password'].value
      );
      this.authService.signIn(signInModel).subscribe(token => {
        sessionStorage.setItem('jwt', token.value);
        this.router.navigate(['/']);
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

}
