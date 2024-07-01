import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyWatchListComponent } from './my-watch-list.component';

describe('MyWatchListComponent', () => {
  let component: MyWatchListComponent;
  let fixture: ComponentFixture<MyWatchListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyWatchListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyWatchListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
