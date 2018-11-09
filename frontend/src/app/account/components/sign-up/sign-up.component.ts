import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';

import { ConfirmPassValdiator } from 'app/account/validators/confirm-pass-validator';

import { AccountService } from 'app/account/services/account.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  email: string = 'Email';
  password: string = 'Password';
  confirmPassword: string = 'ConfirmPassword';
  firstName: string = 'FirstName';
  lastName: string = 'LastName';

  errorMessages: string[] = [];

  signUpForm = this.fb.group({
    FirstName: ['', [
      Validators.required,
      Validators.pattern("[a-zA-ZА-Яа-яёЁ]{2,11}")
    ]],
    LastName: ['', [Validators.required,
      Validators.pattern("[a-zA-ZА-Яа-яёЁ]{2,11}")
    ]],
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]],
    ConfirmPassword: ['', [Validators.required, Validators.minLength(6)]]
  });

  constructor(
    private accountService: AccountService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.signUpForm.controls[this.confirmPassword].setAsyncValidators(
      ConfirmPassValdiator(this.signUpForm));
  }

  onSubmit() : void {
    if(this.signUpForm.valid)
    {
      this.accountService.signUp(this.signUpForm.value).subscribe(x => {
      }, error => {
        this.errorMessages = error.error;
      });
    }
  }

}
