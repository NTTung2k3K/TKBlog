import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../core/authentication.service';
import { User } from '../../domains/user';

@Component({
  selector: 'app-main-admin',
  templateUrl: './main-admin.component.html',
  styleUrl: './main-admin.component.css'
})
export class MainAdminComponent implements OnInit {


  constructor(private _authenService: AuthenticationService) { }

  public userAuthenticated: User | null = null;

  ngOnInit(): void {


    this.loadScripts();
    this.loadStyles();
    this.removePreloader();

    this.userAuthenticated = this._authenService.getUser();

  }
  removePreloader() {
    setTimeout(() => {
      const preloader = document.querySelector('.preloader') as HTMLElement;
      if (preloader) {
        preloader.style.height = '0';
        setTimeout(() => {
          preloader.style.display = 'none';
        }, 200);
      }
    }, 1500);
  }


  private loadScripts() {
    const script = document.createElement('script');
    script.src = 'js/adminlte.js';
    const script2 = document.createElement('script');
    script2.src = 'js/demo.js';
    const script3 = document.createElement('script');
    script3.src = 'js/bootstrap.bundle.min.js';
    document.body.appendChild(script);
    document.body.appendChild(script2);
    document.body.appendChild(script3);
  }

  private loadStyles() {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = 'css/adminlte.min.css';
    document.head.appendChild(link);
  }
  onLogout() {
    this._authenService.logout();
  }
}
