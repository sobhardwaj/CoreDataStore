/* Avoid: 'error TS2304: Cannot find name <type>' during compilation */
///<reference path="../../typings/index.d.ts"/>

import { bootstrap } from '@angular/platform-browser-dynamic';
import { enableProdMode, provide } from '@angular/core';
import { AppComponent, appRouterProviders } from './app.component';
// import { appRouterProviders } from './app.routes';
// import { ROUTER_PROVIDERS } from '@angular/router';

import {
  LocationStrategy,
  HashLocationStrategy,
  APP_BASE_HREF,
} from '@angular/common';

if (window['g_AngularProdMode']) {
  enableProdMode();
}

bootstrap(AppComponent, [
  appRouterProviders,
  provide(APP_BASE_HREF, { useValue: '/' }),
  provide(LocationStrategy, { useClass: HashLocationStrategy })
]);
