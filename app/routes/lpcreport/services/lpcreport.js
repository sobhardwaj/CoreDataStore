System.register(['@angular/core', '@angular/http', 'rxjs/add/operator/map', '../../appsettings'], function(exports_1, context_1) {
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
    var core_1, http_1, appsettings_1;
    var LPCReportService;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (_1) {},
            function (appsettings_1_1) {
                appsettings_1 = appsettings_1_1;
            }],
        execute: function() {
            LPCReportService = (function () {
                function LPCReportService(http) {
                    this.http = http;
                }
                LPCReportService.prototype.getLPCReport = function (id) {
                    return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "LPCReport/" + id)
                        .map(function (res) { return res.json(); });
                };
                ;
                LPCReportService.prototype.putLPCReport = function (id, params) {
                    return this.http.put(appsettings_1.AppSettings.ApiEndpoint + "LPCReport/" + id, params)
                        .map(function (res) { return res; });
                };
                ;
                LPCReportService.prototype.getLPCReports = function (page, limit, borough, objectType) {
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
                LPCReportService.prototype.getLandmarkProperties = function (LPCNumber, page, limit, Sort, Order) {
                    if (page === void 0) { page = 1; }
                    if (limit === void 0) { limit = 100; }
                    var params = new http_1.URLSearchParams();
                    if (Sort && Sort !== '') {
                        params.set('Sort', Sort);
                    }
                    if (Order && Order !== '') {
                        params.set('Order', Order);
                    }
                    if (LPCNumber && LPCNumber !== '') {
                        params.set('LPCNumber', LPCNumber);
                    }
                    return this.http.get(appsettings_1.AppSettings.ApiEndpoint + "LPCReport/landmark/" + limit + "/" + page, { search: params })
                        .map(function (res) { return res.json(); });
                };
                ;
                LPCReportService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], LPCReportService);
                return LPCReportService;
            }());
            exports_1("LPCReportService", LPCReportService);
        }
    }
});
