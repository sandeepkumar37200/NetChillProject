import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-home-navbar',
  templateUrl: './home-navbar.component.html',
  styleUrls: ['./home-navbar.component.css']
})
export class HomeNavbarComponent implements OnInit {

  constructor(private auth:AuthService,private route:Router) { }

  ngOnInit(): void {
  }

  logOut(){
    this.auth.logOut()
    this.route.navigateByUrl('')
  }
}
