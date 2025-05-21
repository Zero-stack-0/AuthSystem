import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent {
  constructor(private router: Router) { }
  navigation = this.router.getCurrentNavigation();
  user = this.navigation?.extras.state?.['user'];
}
