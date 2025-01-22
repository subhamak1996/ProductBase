import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'applogin',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  LoginDetail = {
    username: '',
    password: ''
  };
  constructor(private LoginServive: LoginService, private router: Router) { }

  // Method to handle form submission
  onSubmit() {
    this.LoginServive.Login(this.LoginDetail)
      .subscribe(response => {
        this.router.navigate(['/HomePage']);
        console.log('Logined  successfully:', response);
      }, error => {
        console.error('Error for Login:', error);
      });
  }
}
