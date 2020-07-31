import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getList() {
    return this.http.get<City[]>(this.baseUrl + 'api/city/list');
  }

  getListByState(stateId: number) {
    return this.http.get<City[]>(this.baseUrl + 'api/city/list/' + stateId);
  }
}
