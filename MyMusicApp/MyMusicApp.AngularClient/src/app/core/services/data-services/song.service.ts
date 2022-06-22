import { Injectable, Injector } from '@angular/core';
import { BaseService } from '../../common/base.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SearchModel, SongModel } from '../../models/data-models';
import { SongRequestModel } from '../../models/data-models';

@Injectable({
  providedIn: 'root'
})
export class SongService extends BaseService {

  constructor(injector:Injector) {
    super(injector);
  }

  getAllSongs(page:number,search:SearchModel):Observable<any>{
    let url=`${environment.songsURL}`;
    let songsRequestModel:SongRequestModel={page:page, search:search};
    return this.post(url,songsRequestModel);
  }

  addSong(newSongModel:SongModel):Observable<any>{
    let url=`${environment.addSongURL}`;
    return this.post(url,newSongModel);
  }

  updateSong(songId:number, updatedSongModel:SongModel):Observable<any>{
    let url=`${environment.updateSongByIdURL}/${songId}`;
    return this.update(url,updatedSongModel);
  }

  deleteSong(songId:number):Observable<any>{
    let url=`${environment.songsURL}/${songId}`;
    return this.delete(url);
  }
  
  rateSong(songId:number,rating:number){
    let url=`${environment.rateSongByIdURL}/${songId}`;
    return this.post(url,rating);
  }
}
