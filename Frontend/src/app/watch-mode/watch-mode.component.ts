import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-watch-mode',
  templateUrl: './watch-mode.component.html',
  styleUrls: ['./watch-mode.component.css']
})
export class WatchModeComponent implements OnInit {
  featuredMovieList: any [] = []; 
  data:any;
  id:string;

  addToListBtnValue = {value: "Add to List", disabled: false};
  
  constructor(private movieService:MoviesService , private active:ActivatedRoute,private authService:AuthService ,private router:Router) {
    this.GetAllFeaturedMovieList();
    this.id= <string> active.snapshot.paramMap.get('id');
    this.GetMovieById(this.id);
    movieService.updateMovieList();
   }
 
  ngOnInit(): void {
    
  }

  GetMovieById(id:string ){
    this.movieService.getMovieByIDApi(id).subscribe( d=>{
      this.data=d;
      let yor = new Date(this.data.yor);
        this.data.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});
      console.log(d);
    })

    this.movieService.movieList.subscribe(d=>{
      for(let movie of d) {
        if (movie.id == id) {
          this.addToListBtnValue = {value: 'Movie Added', disabled: true};
          break;
        }
      }
    });
  }

  AddToUserList(){
   let formData={
      movieId: this.id,
      userId: localStorage.getItem('netChillId')
   }
   this.movieService.UserMovieListApi(formData).subscribe()
   this.addToListBtnValue = {value: 'Movie Added', disabled: true};
  }

  
  GetAllFeaturedMovieList(){ // movieId,name, poster, YOR 
    this.movieService.AllFeaturedMovieListApi().subscribe(d=>{
      for(let i of d) {
       
        let yor = new Date(i.yor);
        i.yor = yor.toLocaleDateString('en-US', {year: 'numeric', month: 'long', day: 'numeric'});
        this.featuredMovieList.push(i);
        
      }
      console.log(d);
    })
  }

  goToMovie(id:string){
    console.log(id);
    this.router.navigateByUrl('userView/WatchMode/' + id);
  }
}
