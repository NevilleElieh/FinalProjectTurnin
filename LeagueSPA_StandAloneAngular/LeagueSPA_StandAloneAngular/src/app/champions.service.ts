import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChampionsService {
  constructor(private http: HttpClient) { }

  getChampions(): Observable<any> {
    return this.http.get('/api/Champions');
  }

  getChampionID(id: number): Observable<any> {
    return this.http.get(`/api/Champions/${id}`);
  }
}
