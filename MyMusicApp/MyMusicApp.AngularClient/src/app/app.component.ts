import { ChangeDetectorRef, Component, Injector, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs';
import { BaseComponent } from './core/common/base.component';
import { GlobalLoaderService } from './core/services/shared-services/global-loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends BaseComponent implements OnInit{

  title = 'MyMusicApp MusicApp';
  isLoading:boolean;

  constructor(injector: Injector, private loaderService : GlobalLoaderService, private cdRef:ChangeDetectorRef) {
    super(injector);
  }

  ngAfterViewChecked(){
    this.loaderService.showLoading$
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(
      (res)=>{
        this.isLoading=res;
      }
    );
    this.cdRef.detectChanges();
  }
  ngOnInit(): void{

  }
}
