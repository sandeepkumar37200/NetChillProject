import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { AuthService } from './auth.service';
import { AdminViewService } from './admin-view.service';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  movieList = new Subject<any>();

  constructor(private http: HttpClient, private authService: AuthService, private adminView: AdminViewService) {
    this.updateMovieList();
  }

  setMovieList(list: any) {
    this.movieList.next(list);
  }

  getMovieList(): Observable<any> {
    return this.movieList.asObservable();
  }

  addMovieApi(formData: any): Observable<any> {
    let form=new FormData();
    Object.keys(formData).forEach(key => form.append(key, formData[key]));
    return this.http.post("http://localhost:3000/api/Admin/AddNewMovie", form, {headers: this.adminView.generateToken()});
  }

  getMovieByIDApi(id: string): Observable<any> {
    return this.http.get("http://localhost:3000/api/Movies/GetMovieById/" + id);
  }

  getAllMoviesListOnWelcomePageApi(): Observable<any> {
    return this.http.get("http://localhost:3000/api/Movies/AllMovieList");
  }

  AllFeaturedMovieListApi(): Observable<any> {
    return this.http.get("http://localhost:3000/api/Movies/FeaturedMoviesList");
  }


  AllUpComingMovieListApi(): Observable<any> {
    return this.http.get("http://localhost:3000/api/Movies/UpcomingMoviesList");
  }


  AllNewReleaseMovieListApi(): Observable<any> {
    return this.http.get("http://localhost:3000/api/Movies/NewReleaseMovieList");
  }

  UserMovieListApi(formData: any): Observable<any> {
    return this.http.post("http://localhost:3000/api/Movies/AddMovieToUserList", formData);
  }
  getUserMovieListByEmailApi(email: string | null): Observable<any> {
    console.log(email);
    return this.http.get("http://localhost:3000/api/Movies/UserMovieList/" + email, {headers: this.adminView.generateToken()});
  }

  updateMovieList() {
    console.log("UPDATING")
    this.getUserMovieListByEmailApi(this.authService.userEmail).subscribe(res => {
      console.log(res);
      this.movieList.next(res);
    });
  }
  getAllMovies() {
    return this.http.get('data/properties.json')
  }
}
