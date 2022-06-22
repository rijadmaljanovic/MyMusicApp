import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { SongRoutingModule } from './song-routing.module';
import { SongHomeComponent } from './components/song-home/song-home.component';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { SongListComponent } from './components/song-list/song-list.component';


@NgModule({
  declarations: [
    SongHomeComponent,
    SongListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SongRoutingModule,
    NgbModule
  ]
})
export class SongModule { }
