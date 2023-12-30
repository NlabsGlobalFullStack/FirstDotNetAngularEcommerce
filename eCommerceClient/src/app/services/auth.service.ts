import { Injectable } from '@angular/core';
import { LoginResponseEntity } from '../entities/login-response.entity';
import { jwtDecode } from 'jwt-decode';
import { DecodeEntity } from '../entities/decode.entity';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  hasAuthenticated: boolean = false;
  decode: DecodeEntity = new DecodeEntity();
  token: string = "";

  isAuthenticated() {
    const responseString = localStorage.getItem("response");
    if (responseString) {
      try{
        const response = JSON.parse(responseString) as LoginResponseEntity;
      this.token = response.accessToken;
      this.decode = jwtDecode(this.token);

      const now = new Date().getTime() / 1000;

      if(now > this.decode.exp){
        this.hasAuthenticated = false;
        return false;
      }

      this.hasAuthenticated = true;
      return true;
      }catch (error){
        console.log(error);
  
        this.hasAuthenticated = false;
        return false;      
      }      
    }    
    this.hasAuthenticated = false;
    return false;
  }
}
