"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var ag_grid_ng2_1 = require("ag-grid-ng2");
// import { AgmCoreModule } from '@agm/core';
var core_2 = require("angular2-google-maps/core");
var ng2_select_1 = require("ng2-select/ng2-select");
var ng2_table_1 = require("ng2-table/ng2-table");
var menu_service_1 = require("../core/menu/menu.service");
// import { HomeComponent } from './home/home.component';
var diagnostics_1 = require("./diagnostics/components/diagnostics");
var references_1 = require("./references/components/references");
var referencesList_1 = require("./references/components/referencesList");
var filterSelectbox_1 = require("./references/components/filterSelectbox");
var details_1 = require("./lpcreport/components/details");
var detailForm_1 = require("./lpcreport/components/detailForm");
var maps_1 = require("./maps/components/maps");
var shared_module_1 = require("../shared/shared.module");
var menu_1 = require("./menu");
var routes_1 = require("./routes");
var RoutesModule = (function () {
    function RoutesModule(menu) {
        this.menu = menu;
        menu.addMenu(menu_1.default);
    }
    return RoutesModule;
}());
RoutesModule = __decorate([
    core_1.NgModule({
        imports: [
            shared_module_1.SharedModule,
            ng2_table_1.Ng2TableModule,
            ng2_select_1.SelectModule,
            router_1.RouterModule.forRoot(routes_1.default, { useHash: true }),
            core_2.AgmCoreModule.forRoot({
                apiKey: 'AIzaSyA8okzgfpEduXDLlebJtrgw6cmexiGNoN0'
            }),
            ag_grid_ng2_1.AgGridModule.withComponents([details_1.DetailsComponent])
        ],
        declarations: [
            // HomeComponent,
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
            // HomeComponent,
            diagnostics_1.DiagnosticsComponent,
            filterSelectbox_1.FilterSelectboxComponent,
            references_1.ReferencesComponent,
            referencesList_1.ReferencesListComponent,
            details_1.DetailsComponent,
            maps_1.MapsComponent
        ]
    }),
    __metadata("design:paramtypes", [menu_service_1.MenuService])
], RoutesModule);
exports.RoutesModule = RoutesModule;
