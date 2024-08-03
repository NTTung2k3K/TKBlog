import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginAdminComponent } from './login-admin.component';
import { AuthenticationService } from '../../core/authentication.service';



@NgModule({
  declarations: [LoginAdminComponent],
  imports: [
    CommonModule, ReactiveFormsModule
  ],
  providers: [AuthenticationService]
})
export class LoginAdminModule { }
