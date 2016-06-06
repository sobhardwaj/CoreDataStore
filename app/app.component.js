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
            template: "\n\t\t<alert type=\"info\">ng2-bootstrap hello world!</alert>\n\t\t<h1>My First Angular 2 App!</h1>\n\t"
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
            template: "<a [routerLink]=\"['/']\">home</a>\n\t <a [routerLink]=\"['/second']\">Second</a>\n\t <router-outlet></router-outlet>\n\t"
        }),
        router_1.Routes([
            { path: '/', component: HomeComponent },
            { path: '/second', component: SecondComponent }
        ]), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map