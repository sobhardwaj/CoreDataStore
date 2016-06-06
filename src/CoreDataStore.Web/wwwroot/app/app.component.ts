import { Component } from '@angular/core';
import {AlertComponent} from 'ng2-bootstrap/ng2-bootstrap';

@Component({
  selector: 'my-app',
  directives: [AlertComponent],
  template: `
  	<alert type="info">ng2-bootstrap hello world!</alert>
  	<h1>My First Angular 2 App!</h1>
  `
})
export class AppComponent { }

