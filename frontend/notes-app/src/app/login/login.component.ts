import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userName: string;
  password: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  login() {
     if (this.userName == 'admin' && this.password == 'admin') {
     console.log('user logged in successfully');
     this.router.navigate(['home']);
     } else {
      console.log('user name or password incorrect');
     }
  }
}
