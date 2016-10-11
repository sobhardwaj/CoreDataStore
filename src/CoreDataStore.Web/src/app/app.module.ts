import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';


import { PaginationModule } from 'ng2-bootstrap/ng2-bootstrap';
import { SelectModule } from 'ng2-select/ng2-select';


import { AppComponent } from './app.component';
import { routing, appRoutingProviders } from './app.routing';


import { AboutComponent } from './about/components/about';
import { PageNotFoundComponent } from './pagenotfound/components/pagenotfound';
import { DiagnosticsComponent } from './diagnostics/components/diagnostics';
import { ReferencesComponent } from './references/components/references';
import { ReferencesListComponent } from './references/components/referencesList';
import { DetailsComponent } from './lpcreport/components/details';
import { DetailsListComponent } from './lpcreport/components/detailsList';
import { LandmarksListComponent } from './lpcreport/components/landmarksList';



// import { FilterTextboxComponent } from './components/filterTextbox';
import { FilterSelectboxComponent } from './components/filterSelectbox';

import { CapitalizePipe } from './pipes/capitalize';
import { TrimPipe } from './pipes/trim';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpModule,
    routing,

    PaginationModule,
    SelectModule
  ],
  declarations: [
    AppComponent,
    AboutComponent,
    PageNotFoundComponent,
    DiagnosticsComponent,
    ReferencesComponent,
    ReferencesListComponent,
    DetailsComponent,
    DetailsListComponent,
    LandmarksListComponent,


    FilterSelectboxComponent,
    // FilterTextboxComponent,
    TrimPipe,
    CapitalizePipe,
  ],
  providers: [
    appRoutingProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
