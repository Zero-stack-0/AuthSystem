import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent {
  constructor(private apiService: ApiService, private router: Router) { }

  userDetails: any;
  ngOnInit() {
    this.apiService.getUserDetails().subscribe((data) => {
      if (data.statusCode === 200) {
        this.userDetails = data.data;
      } else {
        this.router.navigate(['/Login']);
      }
    });
  }
}
