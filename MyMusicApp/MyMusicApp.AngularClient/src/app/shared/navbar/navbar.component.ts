import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'src/app/core/common/base.component';
import {  Router } from '@angular/router';
import { takeUntil } from 'rxjs';
import { LoginHelperService } from 'src/app/core/services/shared-services/login-helper.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent extends BaseComponent implements OnInit {

  isUserLogged$:boolean=false;
  isCollapsed = false;
  
  constructor(injector:Injector,
              private loginHelperService: LoginHelperService,
              private router: Router) {
    super(injector);
    
  }

  ngOnInit(): void {
    this.loginHelperService.isUserLogged$
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe((res)=> this.isUserLogged$=res);
  }

  logout(){
    this.loginHelperService.logout();
    this.router.navigate(['/login']);
  }
}
