import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getList() {
    return this.http.get<State[]>(this.baseUrl + 'api/state/list');
  }
}
