import { NgModule } from '@angular/core';

import { LayoutComponent } from './layout.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { HeaderComponent } from './header/header.component';
import { NavsearchComponent } from './header/navsearch/navsearch.component';
import { FooterComponent } from './footer/footer.component';

import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule
  ],
  providers: [],
  declarations: [
    LayoutComponent,
    SidebarComponent,

    HeaderComponent,
    NavsearchComponent,
    FooterComponent
  ],
  exports: [
    LayoutComponent,
    SidebarComponent,

    HeaderComponent,
    NavsearchComponent,
    FooterComponent
  ]
})
export class LayoutModule {}
