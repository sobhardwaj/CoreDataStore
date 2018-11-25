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
var ReferencesService = /** @class */ (function () {
    function ReferencesService(http) {
        this.http = http;
    }
    ReferencesService.prototype.getReferences = function (page, limit, borough, objectType) {
        if (page === void 0) { page = 1; }
        if (limit === void 0) { limit = 10; }
        var params = new http_1.URLSearchParams();
        if (borough && borough !== '') {
            params.set('Borough', borough);
        }
        if (objectType && objectType !== '') {
            params.set('ObjectType', objectType);
        }
        return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "LPCReport/" + limit + "/" + page, { search: params })
            .map(function (res) { return res.json(); });
    };
    ;
    ReferencesService.prototype.getBoroughs = function () {
        return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "Reference/borough")
            .map(function (res) { return res.json(); });
    };
    ;
    ReferencesService.prototype.getObjectTypes = function () {
        return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "Reference/objectType")
            .map(function (res) { return res.json(); });
    };
    ;
    ReferencesService.prototype.getNeighborhoods = function () {
        return this.http.get(appsettings_1.AppSettings.ApiMaps + "Neighborhoods")
            .map(function (res) { return res.json(); });
    };
    ;
    ReferencesService.prototype.getParentStyle = function () {
        return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "Reference/parentStyle")
            .map(function (res) { return res.json(); });
    };
    ;
    var _a;
    ReferencesService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [typeof (_a = typeof http_1.Http !== "undefined" && http_1.Http) === "function" ? _a : Object])
    ], ReferencesService);
    return ReferencesService;
}());
exports.ReferencesService = ReferencesService;
//# sourceMappingURL=references.js.map