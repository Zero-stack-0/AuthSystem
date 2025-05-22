import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  ngOnInit() {
    console.log("Signup Component Initialized");
  }
  constructor(private apiService: ApiService, private router: Router) { }
  userForm = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)])
  });

  apiErrorMessage: string = '';
  isApiError: boolean = false;

  onSubmit() {
    if (this.userForm.valid) {
      this.apiService.signup(this.userForm.value).subscribe((data) => {
        if (data.statusCode === 400) {
          this.isApiError = true;
          this.apiErrorMessage = data.message;
          this.userForm.reset();
          return;
        }
        else {
          this.router.navigate(['/Home'], { state: { user: data.data } });
        }
      });
    }
  }
}

