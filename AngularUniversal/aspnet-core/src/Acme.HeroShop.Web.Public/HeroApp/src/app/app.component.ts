import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  heroCompanies: any = [];
  heroes: any = [];

  ngOnInit(): void {
    this.heroCompanies = [
      {
        id: 1,
        name: 'Marvel Studios'
      }, {
        id: 2,
        name: 'DC Comics'
      }];

    this.heroes = [
      {
        id: 1,
        name: 'Spider-Man',
        heroCompanyId: 1
      },
      {
        id: 2,
        name: 'Hulk',
        heroCompanyId: 1
      },
      {
        id: 3,
        name: 'The-Flash',
        heroCompanyId: 2
      }
    ];
  }

  filterHeroes(heroCompanyId: number): void {
    //todo: ger heroes from server here...
  }

}
