import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-my-watch-list',
  templateUrl: './my-watch-list.component.html',
  styleUrls: ['./my-watch-list.component.css']
})
export class MyWatchListComponent implements OnInit {

  movieList: any[]=[];

  constructor(private movieService: MoviesService) {
    movieService.updateMovieList();
    movieService.movieList.subscribe(d => {
      for(let i of d) {
       
        let yor = new Date(i.yor);
        i.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});
        this.movieList.push(i);
        
      }
    });
  }

  ngOnInit(): void {
  }

}
