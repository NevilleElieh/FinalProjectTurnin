import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Champion } from '../champions/champion';
import { Ability } from './ability';

@Component({
  selector: 'app-abilities',
  templateUrl: './abilities.component.html',
  styleUrls: ['./abilities.component.css']
})
export class AbilitiesComponent implements OnInit {
  public champions: Champion[] = [];
  public abilities: Ability[] = [];
  public hoveredChampionAbilities: Ability[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
     this.http.get<Champion[]>(environment.baseUrl + 'api/Champions')
     .subscribe(result => {
        this.champions = result;
      }, error => console.error(error));

    this.http.get<Ability[]>(environment.baseUrl + 'api/Abilities')
      .subscribe(result => {
        this.abilities = result;
      }, error => console.error(error));
  }

  onChampionHover(championId: number) {
    this.hoveredChampionAbilities = this.abilities.filter(ability => ability.championId === championId);
  }

  onChampionLeave() {
    this.hoveredChampionAbilities = [];
  }
}
