import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginAdminComponent } from './components/login-admin/login-admin.component';
import { MainAdminComponent } from './components/main-admin/main-admin.component';
import { NewsComponent } from './components/main-admin/news/news.component';

const routes: Routes = [
  { path: '', component: LoginAdminComponent },
  {
    path: 'Admin', component: MainAdminComponent, children: [
      { path: 'News', component: NewsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
