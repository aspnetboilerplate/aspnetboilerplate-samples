import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  heroCompanies: any = [];
  originalHeroes: any = [];
  displayHeroes: any = [];

  selectedHeroCompany: string = 'All';


  ngOnInit(): void {
    this.heroCompanies = (window as any).TRANSFER_CACHE.fromDotnet.heroCompanies;
    this.originalHeroes = (window as any).TRANSFER_CACHE.fromDotnet.heroes;
    this.displayHeroes = (window as any).TRANSFER_CACHE.fromDotnet.heroes;
  }

  filterHeroes(heroCompanyId: number): void {
    if (!heroCompanyId) {
      this.displayHeroes = this.originalHeroes;
      this.selectedHeroCompany = 'All';
    } else {
      this.displayHeroes = this.originalHeroes.filter(hero => hero.heroCompanyId === heroCompanyId);
      this.selectedHeroCompany = this.heroCompanies.filter(heroCompany => heroCompany.id === heroCompanyId)[0].name;
    }
  }

}
