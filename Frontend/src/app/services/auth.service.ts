import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router'
import { Observable, Subject } from 'rxjs';
import { MoviesService } from './movies.service';



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userEmail!: string | null;
  userToken = new Subject<string | null>();
  isAdmin = new Subject<boolean | null>();
  userId = new Subject<string | null>();

  constructor(private http: HttpClient) {
    this.userEmail = localStorage.getItem("netChillEmail");
    this.userToken.next(localStorage.getItem("netChillToken"));
    this.isAdmin.next(localStorage.getItem("netChillIsAdmin") === '1' ? true : false);
    this.userId.next(localStorage.getItem("netChillId"));
  }

  registerAPI(formData: any): Observable<any> {
    return this.http.post("http://localhost:3000/api/Auth/register", formData);
  }
 
  loginAPI(formData: any): Observable<any> {
    return this.http.post("http://localhost:3000/api/Auth/login", formData);
  }

  saveLoginInfo(email: string, token: string, isAdmin: boolean,userId :string) {
    this.userEmail = email;
    console.log(email);
    this.userToken.next(token);
    this.isAdmin.next(isAdmin);
    this.userId.next(userId);

    localStorage.setItem("netChillEmail", email);
    localStorage.setItem("netChillToken", token);
    localStorage.setItem("netChillIsAdmin", isAdmin ? '1' : '0');
    localStorage.setItem("netChillId", userId);
  }

  logOut(){
    localStorage.removeItem("netChillEmail");
    localStorage.removeItem("netChillToken");
    localStorage.removeItem("netChillIsAdmin");
    localStorage.removeItem("netChillId");

    this.userEmail = null;
    this.userToken.next(null);
    this.isAdmin.next(null);
    this.userId.next(null);
  }
}
