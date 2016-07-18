import { Component, OnInit } from "@angular/core";
import { ROUTER_PROVIDERS, ROUTER_DIRECTIVES, Routes } from "@angular/router";
import { AlertComponent } from "ng2-bootstrap/ng2-bootstrap";

import { ReferencesComponent } from './references/components/references';
import { AboutComponent } from './about/components/about.components';


/* Providers */
import { HTTP_PROVIDERS } from '@angular/http';
import { FORM_PROVIDERS, LocationStrategy, HashLocationStrategy } from '@angular/common';

import { Sorter } from './utils/sorter';
import { ReferencesService } from './references/services/references';
import { TrackByService } from './services/trackby';

const APP_PROVIDERS = [
  Sorter,
  ReferencesService,
  TrackByService,
  FORM_PROVIDERS,
  HTTP_PROVIDERS,
  //bind(LocationStrategy).toClass(HashLocationStrategy)
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

@Routes([
  { path: '/', component: ReferencesComponent },
  { path: '/about', component: AboutComponent }
])

export class AppComponent implements OnInit {
  ngOnInit() {
    console.log("Application component initialized ...");
  }
}
