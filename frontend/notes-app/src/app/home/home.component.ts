import { Component, Input, OnInit, Output, EventEmitter, Injector, Inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  category : string;
  termSearch: string; 
  isUserLogged: boolean;
  userName: string;
  password: string;

  constructor(private loginService: LoginService ) { }

  receiveCategory(categId: string) {
    this.category = categId;
    console.log(this.category)
  }

  receiveNote(term: string) {
    this.termSearch = term;
  }

  ngOnInit(): void {
  }

  login() {
      this.loginService.checkCredentials(this.userName, this.password).subscribe((isLogged: boolean) => {this.isUserLogged = isLogged});
      if (this.isUserLogged) {
        console.log('user logged in successfully');
        this.isUserLogged = true;
      } else {
        console.log('user name or password incorrect');
      }
  }
}
