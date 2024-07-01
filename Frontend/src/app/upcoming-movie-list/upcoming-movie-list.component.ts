import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-upcoming-movie-list',
  templateUrl: './upcoming-movie-list.component.html',
  styleUrls: ['./upcoming-movie-list.component.css']
})
export class UpcomingMovieListComponent implements OnInit {

  upcomingMovieList:any[]=[];

  constructor(private moviesService:MoviesService, private router:Router) {
    this.GetAllUpComingMovieList();
   }

  ngOnInit(): void {
  }
  GetAllUpComingMovieList(){ // movieId,name, poster, YOR 
    this.moviesService.AllUpComingMovieListApi().subscribe(d=>{
      for(let i of d) {
        let yor = new Date(i.yor);
        i.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});
        this.upcomingMovieList.push(i);
      }
      console.log(d);
    })
  }
  goToMovie(id:string){
    this.router.navigateByUrl("./WatchMode/"+id);
  }
  
}
