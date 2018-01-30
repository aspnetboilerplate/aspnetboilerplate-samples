import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  heroCompanies: any = [];
  heroes: any = [];

  ngOnInit(): void {
    this.heroCompanies = (window as any).TRANSFER_CACHE.fromDotnet.heroCompanies;
    this.heroes = (window as any).TRANSFER_CACHE.fromDotnet.heroes;
  }
  
  filterHeroes(heroCompanyId: number): void {
    //todo: ger heroes from server here...
  }

}
