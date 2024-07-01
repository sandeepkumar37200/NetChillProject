import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { HomeNavbarComponent } from './home-navbar/home-navbar.component';
import { MoviesService } from './services/movies.service';
import { FeatureMoviesListComponent } from './feature-movies-list/feature-movies-list.component';
import { MyWatchListComponent } from './my-watch-list/my-watch-list.component';
import { NewReleaseComponent } from './new-release/new-release.component';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { UploadContentComponent } from './upload-content/upload-content.component';
import { RevokeSubscriptionComponent } from './revoke-subscription/revoke-subscription.component';
import { UserViewComponent } from './user-view/user-view.component';
import { UpcomingMovieListComponent } from './upcoming-movie-list/upcoming-movie-list.component';
import { WatchModeComponent } from './watch-mode/watch-mode.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegistrationComponent,
    WelcomePageComponent,
    HomeNavbarComponent,
    FeatureMoviesListComponent,
    MyWatchListComponent,
    NewReleaseComponent,
    AdminViewComponent,
    UploadContentComponent,
    RevokeSubscriptionComponent,
    UserViewComponent,
    UpcomingMovieListComponent,
    WatchModeComponent,
 
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule

  ],
  providers: [
    MoviesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
