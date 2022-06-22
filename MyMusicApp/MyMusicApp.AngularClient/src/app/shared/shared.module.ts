import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { GlobalLoaderComponent } from './global-loader/global-loader.component';
import { RatingComponent } from './rating/rating.component';


@NgModule({
  declarations: [
    NavbarComponent,
    FooterComponent,
    GlobalLoaderComponent,
    RatingComponent
  ],
  imports: [
    CoreModule,
  ],
  exports:[
    CoreModule, 
    NavbarComponent,
    FooterComponent,
    RatingComponent,
    GlobalLoaderComponent
  ]
})
export class SharedModule { }
