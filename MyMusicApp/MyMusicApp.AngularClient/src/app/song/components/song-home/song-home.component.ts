import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/core/common/base.component';

@Component({
  selector: 'app-song-home',
  templateUrl: './song-home.component.html',
  styleUrls: ['./song-home.component.css']
})
export class SongHomeComponent extends BaseComponent implements OnInit {

constructor(injector:Injector) {
  super(injector);
  
}
  ngOnInit(): void {
  }

}
