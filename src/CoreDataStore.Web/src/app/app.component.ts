import { Component, OnInit } from "@angular/core";
import { ROUTER_DIRECTIVES, provideRouter, RouterConfig } from "@angular/router";
import { AlertComponent } from "ng2-bootstrap/ng2-bootstrap";

import { ReferencesComponent } from './references/components/references';
import { DetailsComponent } from './details/components/details';
import { AboutComponent } from './about/components/about.components';
import { DiagnosticsComponent } from './diagnostics/components/diagnostics';


/* Providers */
import { HTTP_PROVIDERS } from '@angular/http';
import { FORM_PROVIDERS, LocationStrategy, HashLocationStrategy } from '@angular/common';

import { Sorter } from './utils/sorter';
import { ReferencesService } from './references/services/references';
import { DetailsService } from './details/services/details';
import { DiagnosticsService } from './diagnostics/services/diagnostics';
import { TrackByService } from './services/trackby';

const APP_PROVIDERS = [
  Sorter,
  ReferencesService,
  DetailsService,
  DiagnosticsService,
  TrackByService,
  FORM_PROVIDERS,
  HTTP_PROVIDERS,
  //bind(LocationStrategy).toClass(HashLocationStrategy)
];

export const routes: RouterConfig = [
  { path: '', component: ReferencesComponent },
  { path: 'diagnostics', component: DiagnosticsComponent },
  { path: 'about', component: AboutComponent },
  { path: 'details/:id', component: DetailsComponent }
];

// export class HomeComponent {};

export const appRouterProviders = [
  provideRouter(routes)
];


@Component({
  selector: 'home',
  directives: [AlertComponent],
  template: `
		<alert type="info">ng2-bootstrap hello world!</alert>
		<h1>My First Angular 2 App</h1>
	`
})
export class HomeComponent {}

@Component({
  selector: "app",
  templateUrl: "./app/app.html",
  providers: [APP_PROVIDERS],
  directives: [ROUTER_DIRECTIVES]
})
export class AppComponent implements OnInit {
  ngOnInit() {
    console.log("Application component initialized ...");
  }
}
