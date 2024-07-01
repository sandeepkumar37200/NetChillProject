import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcomingMovieListComponent } from './upcoming-movie-list.component';

describe('UpcomingMovieListComponent', () => {
  let component: UpcomingMovieListComponent;
  let fixture: ComponentFixture<UpcomingMovieListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpcomingMovieListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpcomingMovieListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
