export class SignUpModel {
    constructor(
        public Email : string,
        public Password : string, 
        public ConfirmPassword : string,
        public FirstName : string,
        public LastName : string,
        public Country: string
    ) {}
}