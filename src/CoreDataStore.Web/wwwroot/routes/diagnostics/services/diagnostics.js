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
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
var appsettings_1 = require("../../../appsettings");
var DiagnosticsService = /** @class */ (function () {
    function DiagnosticsService(http) {
        this.http = http;
        this.location = {};
        this.location = {
            street: "string",
            address: "string",
            borough: "string",
            neighborhood: "string",
            postalCode: "string",
            state: "string"
        };
    }
    DiagnosticsService.prototype.getDiagnostics = function () {
        return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "Diagnostics").map(function (res) { return res.json(); });
    };
    DiagnosticsService.prototype.getUserRange = function (coords) {
        return this.http.post(appsettings_1.AppSettings.ApiLocation + "Location/api/Location/validate", { coords: coords, location: this.location }).map(function (res) { return res.json(); });
    };
    DiagnosticsService.prototype.getUserLocation = function (coords) {
        return this.http.post(appsettings_1.AppSettings.ApiLocation + "Location", { coords: coords, location: this.location }).map(function (res) { return res.json(); });
    };
    var _a;
    DiagnosticsService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [typeof (_a = typeof http_1.Http !== "undefined" && http_1.Http) === "function" ? _a : Object])
    ], DiagnosticsService);
    return DiagnosticsService;
}());
exports.DiagnosticsService = DiagnosticsService;
//# sourceMappingURL=diagnostics.js.map