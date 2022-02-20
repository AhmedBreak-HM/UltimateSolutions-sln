import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper = new JwtHelperService();
  baseUrl: string = environment.baseUrl + 'auth/';
  decodedToken: any;
  curentUser: User | undefined;
  token:any;
  constructor(private http: HttpClient) { }


  login(model: any) {
    return this.http.post(`${this.baseUrl}logIn`, model).pipe(
      map((res: any) => {
        const user = res;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.user));
          this.curentUser = user.user;
          console.log(this.DecodToken());
          return model;
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(`${this.baseUrl}register`, model);
  }
  isUser() {
    try {
       this.token = localStorage.getItem('token');
      this.DecodToken = this.jwtHelper.decodeToken(this.token);
      return !this.jwtHelper.isTokenExpired(this.token );
    }
    catch {
      return false;
    }
  }
  DecodToken() {
    this.token = localStorage.getItem('token') ;
    const user = this.jwtHelper.decodeToken(this.token);
    return user;
  }

}
