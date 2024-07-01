import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(private router:Router,private auth:AuthService) {

   }

   canActivate(router: ActivatedRouteSnapshot,state: RouterStateSnapshot):boolean{
    let res=localStorage.getItem("netChillIsAdmin") === '1' ? true : localStorage.getItem("netChillIsAdmin")==='0'? false: null;
        if(state.url==='/'){
          if(res===true){
            this.router.navigate(['adminView'])
          }
          else if(res===false){
            this.router.navigate(['userView'])
          }
        }
        else if(state.url.slice(0,9)==='/userView'){
          if(res===null){
            this.router.navigate(['/'])
          }
          else if(res===true){
            this.router.navigate(['adminView'])
          }
          
        }
        else if(state.url.slice(0,10)==='/adminView'){
          if(res===null){
            this.router.navigate(['/'])
          }
          else if(res===false){
            this.router.navigate(['userView'])
          }
        }
        return true;
   }



}
