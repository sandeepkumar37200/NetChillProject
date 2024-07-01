import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-new-release',
  templateUrl: './new-release.component.html',
  styleUrls: ['./new-release.component.css']
})
export class NewReleaseComponent implements OnInit {

  newReleaseMovieList:any[]=[];
  constructor(private moviesService: MoviesService, private router:Router) {
    this.GetAllNewReleaseMovieList();
   }

  ngOnInit(): void {
  }
  GetAllNewReleaseMovieList(){ // movieId,name, poster, YOR 
    this.moviesService.AllNewReleaseMovieListApi().subscribe(d=>{
      for(let i of d) {
       
        let yor = new Date(i.yor);
        i.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});  
        this.newReleaseMovieList.push(i);
        
      }
      console.log(d);
    })
  }

  goToMovie(id:string){
    this.router.navigateByUrl("./WatchMode/"+id);
  }
}
