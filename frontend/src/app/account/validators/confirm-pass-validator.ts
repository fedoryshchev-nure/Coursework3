import { AbstractControl, AsyncValidatorFn, FormGroup } from "@angular/forms";
import { of } from "rxjs";

export function ConfirmPassValdiator(fg: FormGroup): AsyncValidatorFn {
    return (control: AbstractControl) => {    
      return fg.controls['Password'].value != control.value ? of({"match": {value: control.value}}) : of(null);
    };
  }