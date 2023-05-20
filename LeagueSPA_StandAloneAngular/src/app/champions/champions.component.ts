import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Champion } from './champion';
import { Ability } from '../abilities/ability';

@Component({
  selector: 'app-champions',
  templateUrl: './champions.component.html',
  styleUrls: ['./champions.component.css']
})
export class ChampionsComponent implements OnInit {
   champions: Champion[] = [];
  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.http.get<Champion[]>(environment.baseUrl + 'api/Champions')
      .subscribe(result => {
        this.champions = result;
      }, error => console.error(error));
  }

}
