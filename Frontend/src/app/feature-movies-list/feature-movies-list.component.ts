import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-feature-movies-list',
  templateUrl: './feature-movies-list.component.html',
  styleUrls: ['./feature-movies-list.component.css']
})
export class FeatureMoviesListComponent implements OnInit {

  featuredMovieList: any [] = []; 
  constructor(private moviesService: MoviesService , private router: Router) {
    this.GetAllFeaturedMovieList();
   }

  ngOnInit(): void {
  }
  GetAllFeaturedMovieList(){ // movieId,name, poster, YOR 
    this.moviesService.AllFeaturedMovieListApi().subscribe(d=>{
      for(let i of d) {
       
        let yor = new Date(i.yor);
        i.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});
        this.featuredMovieList.push(i);
        
      }
      console.log(d);
    })
  }

  goToMovie(id:string){
    this.router.navigateByUrl("./WatchMode/"+id);
  }
}
