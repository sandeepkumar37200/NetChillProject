import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WatchModeComponent } from './watch-mode.component';

describe('WatchModeComponent', () => {
  let component: WatchModeComponent;
  let fixture: ComponentFixture<WatchModeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WatchModeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WatchModeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
