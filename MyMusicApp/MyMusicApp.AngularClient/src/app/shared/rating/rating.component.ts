import { Component, Injector, Input, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs';
import { BaseComponent } from 'src/app/core/common/base.component';
import { ToastrService } from 'ngx-toastr';
import { AppConstants } from 'src/app/core/common/app-constants';
@Component({
  selector: 'movie-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent extends BaseComponent implements OnInit {

  stars: number[] = [1, 2, 3, 4, 5];
  selectedValue: number = 0;
  isMouseover = true;


constructor(injector: Injector, private toastr: ToastrService ) {
  super(injector);
 
}

  ngOnInit(): void {
  }

  addClass(star: number) {
    if (this.isMouseover) {
      this.selectedValue = star;
    }
   }
  
   removeClass() {
     if (this.isMouseover) {
        this.selectedValue = 0;
     }
    }


}
