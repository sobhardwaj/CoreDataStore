import {ROUTER_PROVIDERS, ROUTER_DIRECTIVES, Routes} from "@angular/router";
import { Component } from "@angular/core";
import {AlertComponent} from "ng2-bootstrap/ng2-bootstrap";

@Component({
  selector:'second',
  template: `<h1>second</h1>`
})

export class SecondComponent{}


@Component({
   selector: 'home',
	directives: [AlertComponent],
	template: `
		<alert type="info">ng2-bootstrap hello world!</alert>
		<h1>My First Angular 2 App!</h1>
	`
})

export class HomeComponent{}




@Component({
	selector: 'my-app',
	directives: [ ROUTER_DIRECTIVES ],
	template: 
	`<a [routerLink]="['/']">home</a>
	 <a [routerLink]="['/second']">Second</a>
	 <router-outlet></router-outlet>
	`
})

@Routes([
	{path :'/', component: HomeComponent},
   	{path :'/second', component : SecondComponent}

])

export class AppComponent { }

