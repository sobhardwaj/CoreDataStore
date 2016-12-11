import { LayoutComponent } from '../layout/layout.component';

import { HomeComponent } from './home/home.component';
import { DiagnosticsComponent } from './diagnostics/components/diagnostics';
import { ReferencesComponent } from './references/components/references';
import { DetailsComponent } from './lpcreport/components/details';

import { GoogleComponent as GoogleMapsComponent } from './maps/google/google.component';

const routes = [

  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'diagnostics', component: DiagnosticsComponent },
      { path: 'references', component: ReferencesComponent },
      { path: 'details/:id', component: DetailsComponent },
      { path: 'maps', children: [{ path: 'google', component: GoogleMapsComponent }] }
    ]

  },

  // Not found
  { path: '**', redirectTo: 'home' }

];

export default routes;
