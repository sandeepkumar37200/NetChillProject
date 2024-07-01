import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-upload-content',
  templateUrl: './upload-content.component.html',
  styleUrls: ['./upload-content.component.css']
})
export class UploadContentComponent implements OnInit {

  @ViewChild('uploadContent')
  uploadContent!: NgForm;


  imageSrc!: string;

  constructor(private addmovies: MoviesService, private router: Router) { }

  ngOnInit(): void {
  }

  readURL(event: Event): void {
    const eventTarget = event.target as HTMLInputElement;
    this.imageSrc=eventTarget.value;
  }

 

  uploadFormSubmit(formData: any){

    if (this.uploadContent.invalid) {       
      return;
    }
  
  

    let data = {
      'Name': formData.name,
      'Category': formData.category,
      'ReleaseYear': formData.releasedate,
      'AvailabilityDate': formData.ASD,
      'Description': formData.description,
      'IsFeatured': formData.isfeatured,          
      'MoviesPosterFile':formData.thumbnail,
      'ContentPathFile':formData.movieFile
    };

    // Is Featured Modify
    if (<string>formData?.isfeatured === '') {           
      formData.isfeatured = false;
    } else {
      formData.isfeatured = true;
    }

    console.log(data);

    this.addmovies.addMovieApi(data).subscribe(d=>{
      alert("Movie uploaded Successfully");
    }, err=>{
      alert("Error occured")
    });
  }


}
