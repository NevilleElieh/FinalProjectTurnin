import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AbilitiesService {
  constructor(private http: HttpClient) { }

  getAbilities(): Observable<any> {
    return this.http.get('/api/Abilities');
  }

  getAbility(id: number): Observable<any> {
    return this.http.get(`/api/Abilities/${id}`);
  }
}
