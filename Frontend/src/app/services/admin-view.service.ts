import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminViewService {

  constructor(private http:HttpClient, private authService: AuthService) { }

  private adminView = new Subject<boolean>();

  getAdminViewStatus(): Observable<boolean> {
    return this.adminView.asObservable();
  }

  toggleAdminView(value: boolean) {
    this.adminView.next(value);
  }

  userlistApi(): Observable<any> {
    return this.http.get("http://localhost:3000/api/Admin/usersList", {headers: this.generateToken()});
  }
  
  revokeSubscriptionApi(id:string): Observable<any> {

    return this.http.put("http://localhost:3000/api/Admin/EditUsersSubscription/"+ id, null, {headers: this.generateToken()});
  }

  generateToken(): HttpHeaders{
    const header = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('netChillToken')});
    return header;
  }
}
