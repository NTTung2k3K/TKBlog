import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../core/authentication.service';

@Component({
  selector: 'app-login-admin',
  templateUrl: './login-admin.component.html',
  styleUrl: './login-admin.component.css'
})
export class LoginAdminComponent {


  constructor(private _authenService: AuthenticationService) { }

  LoginForm: FormGroup = new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  onLogin() {
    if (this.LoginForm.invalid) return;
    var data = {
      username: this.LoginForm.value.username,
      password: this.LoginForm.value.password
    }
    this._authenService.login(data.username, data.password)
  }
}
