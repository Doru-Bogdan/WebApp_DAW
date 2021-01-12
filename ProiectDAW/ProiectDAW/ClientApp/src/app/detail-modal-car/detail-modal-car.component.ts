import { Input, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { User } from '../models/user.model';

import { Vehicle } from '../models/vehicle.model';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-detail-modal-car',
  templateUrl: './detail-modal-car.component.html',
  styleUrls: ['./detail-modal-car.component.css']
})
export class DetailModalCarComponent implements OnInit {
  @Input() public vehicleId;
  private vehicle;
  private currentUser;
  private currentUserSubject;
  
  constructor(private api: UserService, public modal: NgbActiveModal) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
   }

  ngOnInit() {
    this.getVehicle(this.vehicleId);
  }

  getVehicle(id: number) {
    this.api.getVehicle(id)
      .subscribe((data: any) => {
        this.vehicle = data;
        console.log(data);
        this.vehicle.id = id;
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  rentCar() {
    this.api.rentCar(this.currentUserSubject.getValue().id, this.vehicleId)
    .subscribe((data: any) => {
      this.modal.close();
    },
      (error: Error) => {
        console.log('err', error);

      });
  }
}
