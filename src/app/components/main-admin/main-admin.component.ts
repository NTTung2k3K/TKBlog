import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-admin',
  templateUrl: './main-admin.component.html',
  styleUrl: './main-admin.component.css'
})
export class MainAdminComponent implements OnInit {
  ngOnInit(): void {
    this.loadScripts();
    this.loadStyles();
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
}
