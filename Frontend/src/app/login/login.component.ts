import { Component, NgModule, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('loginForm')
  loginForm!: NgForm;

  constructor(private authAPI: AuthService, private router: Router) { }

  ngOnInit(): void {

  }

  onFormSubmit(formData: any) {

    // Check for Email validation
    if ((<string>formData?.['EmailId']).length === 0) {
      this.loginForm.controls['EmailId'].setErrors({ 'required': true });
    }

    // Check for PasswordHash validation
    if ((<string>formData?.['Password']).length === 0) {
      this.loginForm.controls['Password'].setErrors({ 'required': true });
    }

    if (this.loginForm.invalid) {
      return;
    }

    let data = {
      'emailId': formData.EmailId,
      'password': formData.Password
    }

    console.log(data);

    this.authAPI.loginAPI(data).subscribe((res)=>{
      console.log(res);

      this.authAPI.saveLoginInfo(res?.emailId, res?.token, res?.isAdmin, res?.userId);

      if (!res?.isAdmin) {
        this.router.navigateByUrl("userView");
      } else if (res?.isAdmin) {
        this.router.navigateByUrl("adminView");
      } else {
        this.loginForm.form.setErrors({'invalidCred': true});
      }
    },
    (err)=>{
      this.loginForm.form.setErrors({'invalidCred': true})
    });

  }

}
