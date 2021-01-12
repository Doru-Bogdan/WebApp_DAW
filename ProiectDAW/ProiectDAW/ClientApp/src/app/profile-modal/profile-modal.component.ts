import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BehaviorSubject } from 'rxjs';
import { UserDetails } from '../models/user-details.model';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-profile-modal',
  templateUrl: './profile-modal.component.html',
  styleUrls: ['./profile-modal.component.css']
})
export class ProfileModalComponent implements OnInit {
  private currentUser;
  private currentUserSubject;
  selectedUser: any;
  createForm: FormGroup;
  isLoading = false;
  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private userService: UserService, private formBuilder: FormBuilder, private router: Router) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
   }
 
  ngOnInit() {
 
    this.setForm()
  }
 
  onSubmit() {
    if (this.createForm.invalid || this.isLoading) {
      return;
    }
    console.log(this.createForm.value)
    this.isLoading = true;
    this.userService.createProfileDetails(this.createForm.value).subscribe(x => {
      this.isLoading = false;
      this.modal.close('Yes');
    },
      error => {
        this.isLoading = false;
      });
  }
 
  get createFormData() { return this.createForm.controls; }
 
  private setForm() {
    console.log(this.selectedUser);
     
    this.createForm = this.formBuilder.group({
      userId: [this.currentUserSubject.getValue().id],
      firstName: [this.selectedUser.firstName, Validators.required],
      lastName: [this.selectedUser.lastName, Validators.required],
      email: [ this.selectedUser.email],
      // birthDate: [this.selectedUser.birthDate]
    });
  }
}
