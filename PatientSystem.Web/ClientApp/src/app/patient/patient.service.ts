import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getList() {
    return this.http.get<Patient[]>(this.baseUrl + 'api/patient/list');
  }

  add(patient: Patient) {
    return this.http.post(this.baseUrl + 'api/patient/add', patient);
  }
}
