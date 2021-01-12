import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { BehaviorSubject } from 'rxjs';
import { UserDetails } from '../models/user-details.model';
import { User } from '../models/user.model';
import { ProfileModalComponent } from '../profile-modal/profile-modal.component';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  private currentUser;
  private profile;
  private carsRent;
  private currentUserSubject;
  closeResult = '';
 
  constructor(private modalService: NgbModal, private api: UserService) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  ngOnInit(){
    this.getProfile();
    this.getCarsRent();
  }
  
  openModal() {
    // this.router.navigateByUrl(`EditUser/${userModel.id}`);
  
    const ref = this.modalService.open(ProfileModalComponent, { centered: true });
    ref.componentInstance.selectedUser = this.currentUserSubject.value;
  
    ref.result.then((yes) => {
      console.log("Yes Click");
      this.getProfile();
    },
      (cancel) => {
        console.log("Cancel Click");
  
      })
  }

  getProfile() {
    this.api.getProfile(this.currentUserSubject.getValue().id)
      .subscribe((data: any) => {
        this.profile = data;
      },
        (err: Error) => {
          console.log('err', err);
        });
  }

  getCarsRent() {
    this.api.getCarsLoaned(this.currentUserSubject.getValue().id)
      .subscribe((data: any) => {
        this.carsRent = data;
      },
        (err: Error) => {
          console.log('err', err);
        });
  }
}