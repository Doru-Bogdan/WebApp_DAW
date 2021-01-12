import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { appRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AlertComponent } from './alert/alert.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { JwtInterceptor} from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { AddComponent } from './add/add.component';
import { CarsComponent } from './cars/cars.component';
import { DetailModalCarComponent } from './detail-modal-car/detail-modal-car.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProfileComponent } from './profile/profile.component';
import { ProfileModalComponent } from './profile-modal/profile-modal.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AlertComponent,
    LoginComponent,
    RegisterComponent,
    AddComponent,
    CarsComponent,
    DetailModalCarComponent,
    ProfileComponent,
    ProfileModalComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    appRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
