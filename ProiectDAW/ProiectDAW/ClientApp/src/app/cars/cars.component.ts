import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DetailModalCarComponent } from '../detail-modal-car/detail-modal-car.component';
import { Vehicle } from '../models/vehicle.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  cars: Vehicle[] = [];
  title: string;


  constructor(private api: UserService, private modalService: NgbModal) { }

  ngOnInit() {
    this.api.getVehicles().subscribe((data: any[]) => {

      for (let i = 0; i < data.length; i++) {
        this.api.getVehicle(data[i].id).subscribe((info: any) => {
          info.id = data[i].id;

          this.cars.push(info);
          
        },
          (e: Error) => {
            console.log('err', e);
          });
      }
    },
      (er: Error) => {
        console.log('err', er);
      });
  }

  openModal(id: string) {
    const ref = this.modalService.open(DetailModalCarComponent, { centered: true });
    ref.componentInstance.vehicleId = id;
    ref.result.then((yes) => {
      console.log("Yes Click");

      this.api.getVehicles().subscribe((data: any[]) => {
        this.cars = data;
      },
        (er: Error) => {
          console.log('err', er);
        });
    },
      (cancel) => {
        console.log("Cancel Click");

      })
  }

}
