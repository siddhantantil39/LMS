import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { LoginModel } from '../_interfaces/loginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
[x: string]: any;
  invalidLogin?: boolean;
  credentials: LoginModel = {username:'', password:'', role:''};


  constructor(private router: Router, private http: HttpClient) { }

  login(form: NgForm) {
    const credentials = {
      'username': form.value.username,
      'password': form.value.password,
      'role': form.value.role
    }

    this.http.post("https://localhost:7061/api/Auth/login", credentials)
      .subscribe(response => {
        const token = (<any>response).token;
        console.log(token);
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/"]);
      }, err => {
        this.invalidLogin = true;
      })
  }

  
}
