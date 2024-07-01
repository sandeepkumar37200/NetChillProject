import { Component, OnInit } from '@angular/core';
import { AdminViewService } from '../services/admin-view.service';

@Component({
  selector: 'app-revoke-subscription',
  templateUrl: './revoke-subscription.component.html',
  styleUrls: ['./revoke-subscription.component.css']
})
export class RevokeSubscriptionComponent implements OnInit {

  userList: any[] = [];

  constructor(private adminViewService:AdminViewService) {
    this.ListAllUser();
   }

  ngOnInit(): void {
  }

  ListAllUser(){
    this.adminViewService.userlistApi().subscribe(d=> {
      this.userList=[];
      for(let i of d) {
        
        if (!i.isAdmin && i.subscriptionStatus) {
          this.userList.push(i);
        }
      }
      
    })
  }

  revokeSubscription(user: string){
    this.adminViewService.revokeSubscriptionApi(user).subscribe();
    this.ListAllUser();
  }

}
