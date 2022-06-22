import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from './core/guards/auth-guard.service';
import { LoginRouteGuardService } from './core/guards/login-route-guard.service';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
    {
      path: 'song',
      loadChildren: () => import('./song/song.module').then(mod => mod.SongModule),
      canActivate:[AuthGuardService]
    },
    {
      path:'login',
      component:LoginComponent,
      canActivate:[LoginRouteGuardService]
    },
{
  path:'**',
  redirectTo:'/song',
  pathMatch:'full'
},
  {
    path:'',
    redirectTo:'/song',
    pathMatch:'full'
  },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }