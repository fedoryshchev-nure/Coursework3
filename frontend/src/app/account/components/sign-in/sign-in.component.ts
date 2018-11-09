import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { AccountService } from 'app/account/services/account.service';

import { SignInModel } from 'app/account/models/sign-in-model';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  email = 'Email';
  password = 'Password';

  errorMessages: string[] = [];
  warningMessages: string[] = [];

  signInForm = this.fb.group({
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]]
  });

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService
  ) { }

  ngOnInit() {
  }

  private onSubmit() : void {
    if (this.signInForm.valid) {
      const signInModel = new SignInModel(
        this.signInForm.controls['Email'].value,
        this.signInForm.controls['Password'].value
      );
      this.accountService.signIn(signInModel).subscribe(token => {
        sessionStorage['jwt'] = token;
      }, error => {
        this.errorMessages = error.error;
      });
    }
  }

}
