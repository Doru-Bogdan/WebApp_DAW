import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './helpers/auth.guard';
import { AddComponent } from './add/add.component'
import { CarsComponent } from './cars/cars.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'add', component: AddComponent, canActivate: [AuthGuard]},
    { path: 'carsRent', component: CarsComponent, canActivate: [AuthGuard]},
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);