import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SongHomeComponent } from './components/song-home/song-home.component';
import { SongListComponent } from './components/song-list/song-list.component';

const routes: Routes = [ 
{ 
   path:"",
    component: SongHomeComponent,
    children:[
      {path:"", component:SongListComponent},
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SongRoutingModule { }
