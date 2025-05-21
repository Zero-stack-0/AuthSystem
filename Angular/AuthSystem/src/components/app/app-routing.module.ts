import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserHomeComponent } from '../user-home/user-home.component';
import { SignupComponent } from '../signup/signup.component';

const routes: Routes = [
  { path: 'Home', component: UserHomeComponent },
  { path: '', component: SignupComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
