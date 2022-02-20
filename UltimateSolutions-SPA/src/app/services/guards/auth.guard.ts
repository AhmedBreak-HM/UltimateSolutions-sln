import { Injectable } from '@angular/core';
import { CanLoad, Router} from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanLoad {

  constructor(private authService: AuthService, private router: Router) { }
  canLoad(): boolean  {
    return true;

        // if (this.authService.isUser()) {
    //   this.router.navigate(['invoice/invoice']);
    //   return true;
    // } else {
    //   console.log('يجب عليك تسجيل الدخول اولا');
    //   this.router.navigate(['']);
    //   return false;
    // }
  }
}
