import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { PatientService } from '../patient.service';
import { CityService } from '../city.service';
import { StateService } from '../state.service';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-patient-upsert',
  templateUrl: './patient-upsert.component.html',
  styleUrls: ['./patient-upsert.component.css']
})
export class PatientUpsertComponent implements OnInit {
  public patient: Patient = { name: '', cityId: null, dob: new Date(), gender: '', surName: '' };
  public cities: City[];
  public states: State[];
  public genders: Gender[] = [{ name: 'M' }, { name: 'F' }];
  public maxDate: string;
  public minDate: string;

  @ViewChild('dob', { static: false }) dobModel: NgModel;
  ngOnInit() {
    var date = new Date();
    this.maxDate = date.toJSON().split('T')[0];

    var oldDate = date.setFullYear(date.getFullYear() - 100);
    this.minDate = new Date(oldDate).toJSON().split('T')[0];
  }

  constructor(private router: Router, private patientService: PatientService, private cityService: CityService, private stateService: StateService) {
    this.stateService.getList().subscribe(result => {
      this.states = result;
      if (this.states && this.states.length > 0) {
        this.loadCity(this.states[0].id);
      }
    }, error => console.error(error));
  }

  onStateChange(event) {
    let stateId = event.target.value;
    this.loadCity(stateId);
  }

  validateDate(event) {
    let date = event.target.value;

    if (new Date(date) <= new Date(this.maxDate) && new Date(date) >= new Date(this.minDate)) {
      console.log('Valid date: ' + date);
    }
    else {
      this.dobModel.control.setErrors({ 'invalid': true });
    }
  }

  loadCity(stateId) {
    this.cityService.getListByState(stateId).subscribe(result => {
      this.cities = result;
    }, error => console.error(error));
  }

  addPatient(patient: Patient) {    
    this.patientService.add(patient).subscribe(result => {
      console.log(JSON.stringify(result));
      this.router.navigate(['/patients']);
    }, error => {
      console.error(error);
    });
  }
}
