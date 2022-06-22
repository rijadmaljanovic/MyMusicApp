import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SongHomeComponent } from './song-home.component';

describe('SongHomeComponent', () => {
  let component: SongHomeComponent;
  let fixture: ComponentFixture<SongHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SongHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SongHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
