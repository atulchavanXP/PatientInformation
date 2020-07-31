import { Component } from '@angular/core';
import { PatientService } from '../patient.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html'
})
export class PatientListComponent {
  public patients: Patient[];

  constructor(private patientService: PatientService) {
    this.patientService.getList().subscribe(result => {
      this.patients = result;
    }, error => console.error(error));
  }
}
