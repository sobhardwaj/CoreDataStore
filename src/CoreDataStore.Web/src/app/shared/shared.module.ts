import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule, Http } from '@angular/http';
import { Ng2BootstrapModule } from 'ng2-bootstrap/ng2-bootstrap';
import { SelectModule } from 'ng2-select/ng2-select';
import { ToasterModule } from 'angular2-toaster/angular2-toaster';

import { ColorsService } from './colors/colors.service';
import { SessionService } from './services/session';
import { CheckallDirective } from './directives/checkall';
import { NowDirective } from './directives/now';
import { ScrollableDirective } from './directives/scrollable';

import { CapitalizePipe } from './pipes/capitalize';
import { TrimPipe } from './pipes/trim';

// https://angular.io/styleguide#!#04-10
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2BootstrapModule,
    SelectModule,
    ToasterModule
  ],
  providers: [
    ColorsService,
    SessionService
  ],
  declarations: [
    TrimPipe,
    CapitalizePipe,
    CheckallDirective,
    NowDirective,
    ScrollableDirective
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    RouterModule,
    Ng2BootstrapModule,
    ToasterModule,

    TrimPipe,
    CapitalizePipe,

    CheckallDirective,
    NowDirective,
    ScrollableDirective
  ]
})
export class SharedModule {}
