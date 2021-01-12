import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  // styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  options = ['CarBrand', 'Vehicle'];
  selectedOption = 'Vehicle';
  currentFormRef: any;
  addCarBrandForm: FormGroup;
  addVehicleForm: FormGroup;
  success: boolean;

  constructor(public fb: FormBuilder, private api: UserService) { }

  ngOnInit(): void {
    this.addCarBrandForm = this.fb.group({
      brandName: [null, Validators.required],
    });
    this.addVehicleForm = this.fb.group({
      carBrandId: [null, Validators.required],
      vehicleName : [null, Validators.required],
      engineCapacity : [null, Validators.required],
      enginePower : [null, Validators.required],
      trunkSpace :[null, Validators.required]
    });

    this.currentFormRef = this.addVehicleForm;
  }

  radioChange(event: any) {
    this.selectedOption = event.target.value;
    this.currentFormRef = this['add' + this.selectedOption + 'Form'];
  }

  add() {
    this.api['add' + this.selectedOption](this.currentFormRef.value).subscribe(() => {

      this.currentFormRef.reset();
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
      (error: Error) => {
        console.log(error);
        this.currentFormRef.reset();
        this.success = false;
        setTimeout(() => {
          this.success = null;
        }, 3000);
      });

  }

}
