import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { User } from '../models/user.model';
import {Vehicle} from '../models/vehicle.model';
import { CarBrand } from '../models/car-brand.model';
import { UserDetails } from '../models/user-details.model';

@Injectable({ providedIn: 'root' })
export class UserService {
    private apiUrl = "https://localhost:44370/api"
    constructor(private http: HttpClient) { }

    header = new HttpHeaders({
        'Content-Type': 'application/json'
      });

    getAll() {
        return this.http.get<User[]>(`${this.apiUrl}/Auth/getAll`);
    }

    register(user: User) {
        return this.http.post(`${this.apiUrl}/Auth/register`, user);
    }

    delete(id: number) {
        return this.http.delete(`${this.apiUrl}/Auth/${id}`);
    }

    addCarBrand(carBrand: CarBrand) {
        return this.http.post(this.apiUrl + '/CarBrand/create', {
            'brandName' : carBrand.brandName
        }, { headers: this.header });
    }

    addVehicle(vehicle: Vehicle) {
        return this.http.post(this.apiUrl + '/Vehicle/create', vehicle);
    }

    getVehicle(id: number) {
        return this.http.get(this.apiUrl + '/Vehicle/' + id.toString(), { headers: this.header });
    }

    getVehicles() {
        return this.http.get<Vehicle[]>(`${this.apiUrl}/Vehicle/all`);
    }

    rentCar(idUser: number, idCar: number) {
        return this.http.post(this.apiUrl + '/Auth/carLoan', {
            'userId' : idUser,
            'vehicleId' : idCar
        }, { headers: this.header });
    }

    createProfileDetails(userDetails : any) {
        return this.http.post(this.apiUrl + '/UserDetails/create', userDetails);
    }

    getProfile(id: number) {
        return this.http.get(this.apiUrl + `/Auth/getUserDetails/${id}`);
    }

    getCarsLoaned(id: number) {
        return this.http.get(this.apiUrl+ `/Auth/getCarsLoaned/${id}`);
    }
}