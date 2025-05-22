import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private apiService: ApiService, private router: Router) { }
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)])
  });

  login() {
    if (this.loginForm.valid) {
      this.apiService.Login(this.loginForm.value).subscribe((data) => {
        if (data.statusCode === 200) {
          this.router.navigate(['/Home']);
          this.loginForm.reset();
          return;
        }
        else {
          alert("Login Successful");
        }
      });
    }
    else {
      alert("Please fill all the fields");
    }
  }
}
