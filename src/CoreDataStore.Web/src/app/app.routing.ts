import { APP_BASE_HREF } from '@angular/common';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from './about/components/about';
import { PageNotFoundComponent } from './pagenotfound/components/pagenotfound';
import { DiagnosticsComponent } from './diagnostics/components/diagnostics';
import { ReferencesComponent } from './references/components/references';
import { DetailsComponent } from './lpcreport/components/details';

const appRoutes: Routes = [
    { path: 'details/:id', component: DetailsComponent },
    { path: 'diagnostics', component: DiagnosticsComponent },
    { path: 'references', component: ReferencesComponent },
    { path: 'about', component: AboutComponent },
    { path: '', component: AboutComponent },
    { path: '**', component: PageNotFoundComponent }
];
export const appRoutingProviders: any[] = [{
    provide: APP_BASE_HREF,
    useValue: '/'
}];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
