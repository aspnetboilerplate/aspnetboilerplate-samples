﻿import { Component, OnInit, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  templateUrl: './topbar-languageswitch.component.html',
  selector: 'topbar-languageswitch',
  encapsulation: ViewEncapsulation.None
})
export class TopBarLanguageSwitchComponent extends AppComponentBase implements OnInit {

  languages: abp.localization.ILanguageInfo[];
  currentLanguage: abp.localization.ILanguageInfo;
  
  constructor(
    injector: Injector
  ) {
    super(injector);
  }

  ngOnInit() {
    this.languages = this.localization.languages;
    this.currentLanguage = this.localization.currentLanguage;
  }

  changeLanguage(languageName: string): void {
    abp.utils.setCookieValue(
      "Abp.Localization.CultureName",
      languageName,
      new Date(new Date().getTime() + 5 * 365 * 86400000), //5 year
      abp.appPath
    );

    location.reload();
  }
}