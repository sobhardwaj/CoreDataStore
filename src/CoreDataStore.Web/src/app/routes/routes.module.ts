import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { TreeModule } from 'angular2-tree-component';
import { DndModule } from 'ng2-dnd';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { SelectModule } from 'ng2-select';

import { MenuService } from '../core/menu/menu.service';

import { HomeComponent } from './home/home.component';

import { Dashboardv1Component } from './dashboard/dashboardv1/dashboardv1.component';
import { GoogleComponent as GoogleMapsComponent } from './maps/google/google.component';


import { SharedModule } from '../shared/shared.module';

import appMenu from './menu';
import appRoutes from './routes';

@NgModule({
  imports: [
    SharedModule,
    DndModule.forRoot(),
    InfiniteScrollModule,
    RouterModule.forRoot(appRoutes, { useHash: true }),
  ],
  declarations: [
    HomeComponent,
    Dashboardv1Component,
    GoogleMapsComponent,

  ],
  providers: [],
  exports: [
    RouterModule,
    DndModule,
    InfiniteScrollModule,
    HomeComponent,
    Dashboardv1Component,
    GoogleMapsComponent,

  ]
})

export class RoutesModule {
  constructor(private menu: MenuService) {
    menu.addMenu(appMenu);
  }
}
