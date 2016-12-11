import { LayoutComponent } from '../layout/layout.component';

import { HomeComponent } from './home/home.component';
import { Dashboardv1Component } from './dashboard/dashboardv1/dashboardv1.component';
import { ColorsComponent } from './elements/colors/colors.component';
import { GoogleComponent as GoogleMapsComponent } from './maps/google/google.component';

const routes = [

  {
    path: '',
    component: LayoutComponent,
    children: [

      { path: 'home', component: HomeComponent },

      {
        path: 'dashboard',
        children: [
          { path: 'v1', component: Dashboardv1Component }
        ]
      }, {
        path: 'maps',
        children: [
          { path: 'google', component: GoogleMapsComponent },
        ]
      },
    ]

  },

  // Not found
  { path: '**', redirectTo: 'home' }

];

export default routes;
