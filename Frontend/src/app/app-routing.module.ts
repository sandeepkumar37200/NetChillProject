import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { FeatureMoviesListComponent } from './feature-movies-list/feature-movies-list.component';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MyWatchListComponent } from './my-watch-list/my-watch-list.component';
import { NewReleaseComponent } from './new-release/new-release.component';
import { RegistrationComponent } from './registration/registration.component';
import { RevokeSubscriptionComponent } from './revoke-subscription/revoke-subscription.component';
import { AuthGuardService } from './services/auth-guard.service';
import { UpcomingMovieListComponent } from './upcoming-movie-list/upcoming-movie-list.component';
import { UploadContentComponent } from './upload-content/upload-content.component';
import { UserViewComponent } from './user-view/user-view.component';
import { WatchModeComponent } from './watch-mode/watch-mode.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';


const routes: Routes = [
 // { path: '', redirectTo: '', pathMatch: 'full' },
  {path:'',component: WelcomePageComponent,canActivate:[AuthGuardService]},// by default 
  {path: 'userView', component: UserViewComponent,canActivate:[AuthGuardService],
    children: [
      {path: '', component: HomeComponent},
      {path: 'featureList', component: FeatureMoviesListComponent},
      {path: 'NewRelease', component: NewReleaseComponent},
      {path: 'UpComing',component: UpcomingMovieListComponent},
      {path: 'MyList', component: MyWatchListComponent},
      {path:'WatchMode', children:[
        {path: ':id', component: WatchModeComponent}
      ]}
     
    ]},
  {path:'login',component: LoginComponent},
  {path:'signup',component: RegistrationComponent},
  {path:'adminView',component:AdminViewComponent,canActivate:[AuthGuardService],
    children: [
      {path: '', component: HomeComponent},
      {path: 'featureList', component: FeatureMoviesListComponent},
      {path: 'NewRelease', component: NewReleaseComponent},
      {path: 'UpComing',component: UpcomingMovieListComponent},
      {path: 'MyList', component: MyWatchListComponent},
      {path:'Subscription', component:RevokeSubscriptionComponent},
      {path:'UploadContent', component:UploadContentComponent},
      {path:'WatchMode', children:[
        {path: ':id', component: WatchModeComponent}
      ]}
    ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
