import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SignupComponent } from '../signup/signup.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ApiService } from '../../services/api.service';
import { UserHomeComponent } from '../user-home/user-home.component';
import { LoginComponent } from '../login/login.component';
import { AuthInterceptor } from 'src/app/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    UserHomeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,

  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
