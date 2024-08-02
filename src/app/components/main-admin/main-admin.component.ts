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
    this.userAuthenticated = this._authenService.getUser();

  }
  private loadScripts() {
    const script = document.createElement('script');
    script.src = 'js/adminlte.js';
    document.body.appendChild(script);
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
