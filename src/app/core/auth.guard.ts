import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authSerivce = inject(AuthenticationService);
  if (authSerivce.getUser != null) return true;
  else {
    const router = inject(Router);
    router.navigate(['/login']);
    return false;
  }

};
