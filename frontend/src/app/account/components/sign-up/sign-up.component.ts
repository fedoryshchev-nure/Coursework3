import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder } from '@angular/forms';

import { ConfirmPassValdiator } from 'app/account/validators/confirm-pass-validator';

import { AuthService } from 'app/core/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  email = 'Email';
  password = 'Password';
  confirmPassword = 'ConfirmPassword';
  firstName = 'FirstName';
  lastName = 'LastName';

  errorOccurd = false;

  signUpForm = this.fb.group({
    FirstName: ['', [
      Validators.required,
      Validators.pattern('[a-zA-ZА-Яа-яёЁ]{2,11}')
    ]],
    LastName: ['', [Validators.required,
      Validators.pattern('[a-zA-ZА-Яа-яёЁ]{2,11}')
    ]],
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]],
    ConfirmPassword: ['', [Validators.required, Validators.minLength(6)]]
  });

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.signUpForm.controls[this.confirmPassword].setAsyncValidators(
      ConfirmPassValdiator(this.signUpForm));
  }

  onSubmit():
   void {
    if (this.signUpForm.valid) {
      this.authService.signUp(this.signUpForm.value).subscribe(x => {
        this.router.navigate(['/account/signin']);
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

}
