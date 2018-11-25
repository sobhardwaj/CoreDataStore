"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var layout_component_1 = require("../layout/layout.component");
// import { HomeComponent } from './home/home.component';
var diagnostics_1 = require("./diagnostics/components/diagnostics");
var references_1 = require("./references/components/references");
var details_1 = require("./lpcreport/components/details");
var maps_1 = require("./maps/components/maps");
var routes = [
    {
        path: '',
        component: layout_component_1.LayoutComponent,
        children: [
            // { path: 'home', component: HomeComponent },
            { path: 'diagnostics', component: diagnostics_1.DiagnosticsComponent },
            { path: 'references', component: references_1.ReferencesComponent },
            { path: 'details/:id', component: details_1.DetailsComponent },
            { path: 'maps', component: maps_1.MapsComponent },
            { path: '**', redirectTo: 'references' }
        ]
    },
    // Not found
    { path: '**', redirectTo: 'references' }
];
exports.default = routes;
//# sourceMappingURL=routes.js.map