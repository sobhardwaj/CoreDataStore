System.register(['@angular/core', '@angular/router', 'ng2-dnd', 'angular2-infinite-scroll', 'angular2-google-maps', 'ng2-select/ng2-select', 'ng2-table/ng2-table', '../core/menu/menu.service', './home/home.component', './diagnostics/components/diagnostics', './references/components/references', './references/components/referencesList', './references/components/filterSelectbox', './lpcreport/components/details', './lpcreport/components/detailForm', './maps/components/maps', '../shared/shared.module', './menu', './routes'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, ng2_dnd_1, angular2_infinite_scroll_1, angular2_google_maps_1, ng2_select_1, ng2_table_1, menu_service_1, home_component_1, diagnostics_1, references_1, referencesList_1, filterSelectbox_1, details_1, detailForm_1, maps_1, shared_module_1, menu_1, routes_1;
    var RoutesModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (ng2_dnd_1_1) {
                ng2_dnd_1 = ng2_dnd_1_1;
            },
            function (angular2_infinite_scroll_1_1) {
                angular2_infinite_scroll_1 = angular2_infinite_scroll_1_1;
            },
            function (angular2_google_maps_1_1) {
                angular2_google_maps_1 = angular2_google_maps_1_1;
            },
            function (ng2_select_1_1) {
                ng2_select_1 = ng2_select_1_1;
            },
            function (ng2_table_1_1) {
                ng2_table_1 = ng2_table_1_1;
            },
            function (menu_service_1_1) {
                menu_service_1 = menu_service_1_1;
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
            function (referencesList_1_1) {
                referencesList_1 = referencesList_1_1;
            },
            function (filterSelectbox_1_1) {
                filterSelectbox_1 = filterSelectbox_1_1;
            },
            function (details_1_1) {
                details_1 = details_1_1;
            },
            function (detailForm_1_1) {
                detailForm_1 = detailForm_1_1;
            },
            function (maps_1_1) {
                maps_1 = maps_1_1;
            },
            function (shared_module_1_1) {
                shared_module_1 = shared_module_1_1;
            },
            function (menu_1_1) {
                menu_1 = menu_1_1;
            },
            function (routes_1_1) {
                routes_1 = routes_1_1;
            }],
        execute: function() {
            RoutesModule = (function () {
                function RoutesModule(menu) {
                    this.menu = menu;
                    menu.addMenu(menu_1.default);
                }
                RoutesModule = __decorate([
                    core_1.NgModule({
                        imports: [
                            shared_module_1.SharedModule,
                            ng2_table_1.Ng2TableModule,
                            ng2_select_1.SelectModule,
                            ng2_dnd_1.DndModule.forRoot(),
                            angular2_infinite_scroll_1.InfiniteScrollModule,
                            router_1.RouterModule.forRoot(routes_1.default, { useHash: true }),
                            angular2_google_maps_1.AgmCoreModule.forRoot({
                                apiKey: 'AIzaSyA8okzgfpEduXDLlebJtrgw6cmexiGNoN0'
                            })
                        ],
                        declarations: [
                            home_component_1.HomeComponent,
                            diagnostics_1.DiagnosticsComponent,
                            references_1.ReferencesComponent,
                            filterSelectbox_1.FilterSelectboxComponent,
                            referencesList_1.ReferencesListComponent,
                            details_1.DetailsComponent,
                            detailForm_1.DetailFormComponent,
                            maps_1.MapsComponent,
                        ],
                        providers: [],
                        exports: [
                            router_1.RouterModule,
                            ng2_dnd_1.DndModule,
                            ng2_table_1.Ng2TableModule,
                            angular2_google_maps_1.AgmCoreModule,
                            angular2_infinite_scroll_1.InfiniteScrollModule,
                            home_component_1.HomeComponent,
                            diagnostics_1.DiagnosticsComponent,
                            filterSelectbox_1.FilterSelectboxComponent,
                            references_1.ReferencesComponent,
                            referencesList_1.ReferencesListComponent,
                            details_1.DetailsComponent,
                            maps_1.MapsComponent
                        ]
                    }), 
                    __metadata('design:paramtypes', [menu_service_1.MenuService])
                ], RoutesModule);
                return RoutesModule;
            }());
            exports_1("RoutesModule", RoutesModule);
        }
    }
});
