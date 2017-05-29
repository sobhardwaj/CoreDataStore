import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule, Http } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { ToastModule } from 'ng2-toastr/ng2-toastr';

// import { CollapseModule } from 'ngx-bootstrap/collapse';
// import { DatepickerModule } from 'ngx-bootstrap/datepicker';
// import { PaginationModule } from 'ngx-bootstrap/pagination';
import { CollapseModule, DatepickerModule, PaginationModule } from 'ngx-bootstrap';

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
    BrowserAnimationsModule,

    DatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    CollapseModule.forRoot(),

    ToastModule.forRoot()
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

    DatepickerModule,
    PaginationModule,
    CollapseModule,
    ToastModule,

    TrimPipe,
    CapitalizePipe,

    CheckallDirective,
    NowDirective,
    ScrollableDirective
  ]
})
export class SharedModule {}
