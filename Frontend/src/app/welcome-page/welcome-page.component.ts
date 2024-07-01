import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-welcome-page',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css']
})
export class WelcomePageComponent implements OnInit {

  popUpStatus= false;
 
  allMovieList: any[] = []; 
  constructor(private moviesService : MoviesService , private domSanitizer:DomSanitizer) { 
    this.getAllMoviesList();
  }

  ngOnInit(): void {
  }

  getAllMoviesList(){
    this.moviesService. getAllMoviesListOnWelcomePageApi().subscribe(d=>{
      for(let i of d) {

        let yor = new Date(i.yor);
        i.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});
          this.allMovieList.push(i);
      
      }

      console.log(d);
    })
  }


  openPopUp(val: boolean){
    this.popUpStatus=val;
  }

}
