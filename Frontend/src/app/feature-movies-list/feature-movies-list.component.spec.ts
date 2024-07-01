import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeatureMoviesListComponent } from './feature-movies-list.component';

describe('FeatureMoviesListComponent', () => {
  let component: FeatureMoviesListComponent;
  let fixture: ComponentFixture<FeatureMoviesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeatureMoviesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeatureMoviesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
