System.register(['../layout/layout.component', './home/home.component', './diagnostics/components/diagnostics', './references/components/references', './lpcreport/components/details', './maps/components/maps'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var layout_component_1, home_component_1, diagnostics_1, references_1, details_1, maps_1;
    var routes;
    return {
        setters:[
            function (layout_component_1_1) {
                layout_component_1 = layout_component_1_1;
            },
            function (home_component_1_1) {
                home_component_1 = home_component_1_1;
            },
            function (diagnostics_1_1) {
                diagnostics_1 = diagnostics_1_1;
            },
            function (references_1_1) {
                references_1 = references_1_1;
            },
            function (details_1_1) {
                details_1 = details_1_1;
            },
            function (maps_1_1) {
                maps_1 = maps_1_1;
            }],
        execute: function() {
            routes = [
                {
                    path: '',
                    component: layout_component_1.LayoutComponent,
                    children: [
                        { path: '', component: home_component_1.HomeComponent },
                        { path: 'home', component: home_component_1.HomeComponent },
                        { path: 'diagnostics', component: diagnostics_1.DiagnosticsComponent },
                        { path: 'references', component: references_1.ReferencesComponent },
                        { path: 'details/:id', component: details_1.DetailsComponent },
                        { path: 'maps', component: maps_1.MapsComponent }
                    ]
                },
                // Not found
                { path: '**', redirectTo: 'home' }
            ];
            exports_1("default",routes);
        }
    }
});
