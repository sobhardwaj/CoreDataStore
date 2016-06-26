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
var router_1 = require("@angular/router");
var core_1 = require("@angular/core");
var ng2_bootstrap_1 = require("ng2-bootstrap/ng2-bootstrap");
var properties_component_1 = require('./components/properties.component');
/* Providers */
var http_1 = require('@angular/http');
var common_1 = require('@angular/common');
var sorter_1 = require('./utils/sorter');
var data_service_1 = require('./services/data.service');
var trackby_service_1 = require('./services/trackby.service');
var APP_PROVIDERS = [
    sorter_1.Sorter,
    data_service_1.DataService,
    trackby_service_1.TrackByService,
    common_1.FORM_PROVIDERS,
    http_1.HTTP_PROVIDERS,
];
var SecondComponent = (function () {
    function SecondComponent() {
    }
    SecondComponent = __decorate([
        core_1.Component({
            selector: 'second',
            template: "<h1>second</h1>"
        }), 
        __metadata('design:paramtypes', [])
    ], SecondComponent);
    return SecondComponent;
}());
exports.SecondComponent = SecondComponent;
var HomeComponent = (function () {
    function HomeComponent() {
    }
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'home',
            directives: [ng2_bootstrap_1.AlertComponent],
            template: "\n\t\t<alert type=\"info\">ng2-bootstrap hello world!</alert>\n\t\t<h1>My First Angular 2 App</h1>\n\t"
        }), 
        __metadata('design:paramtypes', [])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [APP_PROVIDERS],
            template: "\n\t\t<div class=\"navbar navbar-inverse navbar-fixed-top\">\n\t        <div class=\"container\">\n\t            <div class=\"navbar-header\">\n\t                <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">\n\t                    <span class=\"sr-only\">Toggle navigation</span>\n\t                    <span class=\"icon-bar\"></span>\n\t                    <span class=\"icon-bar\"></span>\n\t                    <span class=\"icon-bar\"></span>\n\t                </button>\n\t                <a asp-controller=\"Home\" asp-action=\"Index\" class=\"navbar-brand\">CoreDataStore.Web</a>\n\t            </div>\n\t            <div class=\"navbar-collapse collapse\">\n\t                <ul class=\"nav navbar-nav\">\n\t                    <li><a asp-controller=\"Home\" asp-action=\"Index\">Home</a></li>\n\t                    <li><a href=\"/swagger/ui/index.html\">Swagger</a></li>\n\t                </ul>\n\t            </div>\n\t        </div>\n\t    </div>\n\n\t\t<a [routerLink]=\"['/']\">home</a>\n\t \t<a [routerLink]=\"['/second']\">Second</a>\n\t \t<router-outlet></router-outlet>\n\t"
        }),
        router_1.Routes([
            { path: '/', component: properties_component_1.PropertiesComponent },
            { path: '/second', component: SecondComponent }
        ]), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map