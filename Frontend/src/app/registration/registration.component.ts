import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, NonNullableFormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  // userSubmitted: boolean = false;
  // passwordPattern: string = "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
  // namePattern: string = "^[a-zA-Z ,.'-]+$";
  // emailPattern: string = "^[a-zA-Z0-9.! #$%&'*+/=? ^_`{|}~-]+@[a-zA-Z0-9-]+(?:\. [a-zA-Z0-9-]+)*$";
  // onlyAlphaNumericPattern: string = "^[a-zA-Z0-9]*$";
  // onlyNumberPattern: string = "^[0-9]+$";

  // RegExpressions for validation
  nameRegExp: RegExp = new RegExp("^[a-zA-Z ,.'-]+$");
  emailRegExp: RegExp = new RegExp("^[a-zA-Z0-9.! #$%&'*+/=? ^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
  passwordRegExp: RegExp = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");

  @ViewChild('registerForm')
  registerForm!: NgForm;

  showSuccessMessage = false;
  showErrorMessage = false;
  
  constructor(private authAPI: AuthService, private router: Router) { }
  
  ngOnInit(): void { }
  onFormSubmit(formData: any) {
    console.log(formData);

    // Check for Name validation
    if ((<string>formData?.['FullName']).length === 0) {
      this.registerForm.controls['FullName'].setErrors({ 'required': true });
    } else if (!this.nameRegExp.test(<string>formData?.['FullName'])) {
      this.registerForm.controls['FullName'].setErrors({ 'incorrect': true });
    }

    // Check for Email validation
    if ((<string>formData?.['emailId']).length === 0) {
      this.registerForm.controls['emailId'].setErrors({ 'required': true });
    } else if (!this.emailRegExp.test(<string>formData?.['emailId'])) {
      this.registerForm.controls['emailId'].setErrors({ 'incorrect': true });
    }

    // Check for PasswordHash validation
    if ((<string>formData?.['passwordHash']).length === 0) {
      this.registerForm.controls['passwordHash'].setErrors({ 'required': true });
    } else if ((<string>formData?.['passwordHash']).length < 8) {
      this.registerForm.controls['passwordHash'].setErrors({ 'minlen': true });
    } else if (!this.passwordRegExp.test(<string>formData?.['passwordHash'])) {
      this.registerForm.controls['passwordHash'].setErrors({ 'incorrect': true });
    }

    // Check for PasswordSalt validation
    if ((<string>formData?.['passwordSalt']).length === 0) {
      this.registerForm.controls['passwordSalt'].setErrors({ 'required': true });
    } else if (<string>formData?.['passwordSalt'].match(<string>formData?.['passwordHash']) === null) {
      this.registerForm.controls['passwordSalt'].setErrors({ 'mismatch': true });
    }

    if (this.registerForm.invalid) {
      return;
    }

    let data = {
      'emailId': formData.emailId,
      'fullName': formData.FullName,
      'unHashedPassword': formData.passwordHash,
      'confirmPassword': formData.passwordSalt
    };

    this.authAPI.registerAPI(data).subscribe((res)=>{
      console.log(res);
      if (res?.status === 400) {
        this.registerForm.form.setErrors({'conflict': true});
      } else if (res ===null || res?.status === 200) {
        this.showSuccessMessage = true;
      } else {
        this.showErrorMessage = true;
      }
      // On successful submission reset the form open popup
      this.registerForm.resetForm();
      this.registerForm.form.markAsUntouched();
    },(err)=>{
      if (err?.status === 400) {
        this.registerForm.form.setErrors({'conflict': true});
      } else {
        this.showErrorMessage = true;
      }
    });

  }

  goToHome(){
    this.showSuccessMessage = false;
    this.router.navigateByUrl("userView");
  }

  hideErrorMessage(){
    this.showErrorMessage = false;
  }

}
