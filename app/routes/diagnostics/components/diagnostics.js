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
var Rx_1 = require("rxjs/Rx");
var appsettings_1 = require("../../appsettings");
var diagnostics_1 = require("../services/diagnostics");
var DiagnosticsComponent = (function () {
    function DiagnosticsComponent(diagnosticsService) {
        this.diagnosticsService = diagnosticsService;
        this.build = appsettings_1.AppSettings.build;
        this.ApiEndpoint = appsettings_1.AppSettings.ApiEndpoint;
        this.ApiAttraction = appsettings_1.AppSettings.ApiAttraction;
        this.ApiMaps = appsettings_1.AppSettings.ApiMaps;
        this.ApiReports = appsettings_1.AppSettings.ApiReports;
        this.ng2ENV = appsettings_1.AppSettings.ng2ENV;
        this.diagnostics = [];
    }
    DiagnosticsComponent.prototype.getDiagnostics = function () {
        var _this = this;
        this.diagnosticsService.getDiagnostics().subscribe(function (data) { _this.diagnostics = data; }, function (err) { return console.error(err); }, function () { return console.log('done loading diagnostics'); });
    };
    DiagnosticsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.timer = Rx_1.Observable.interval(1000).subscribe(function () { _this.getDiagnostics(); });
    };
    DiagnosticsComponent.prototype.ngOnDestroy = function () {
        this.timer.unsubscribe();
    };
    return DiagnosticsComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], DiagnosticsComponent.prototype, "diagnostics", void 0);
DiagnosticsComponent = __decorate([
    core_1.Component({
        selector: 'diagnostics',
        providers: [diagnostics_1.DiagnosticsService],
        templateUrl: 'app/routes/diagnostics/components/diagnostics.html'
    }),
    __metadata("design:paramtypes", [diagnostics_1.DiagnosticsService])
], DiagnosticsComponent);
exports.DiagnosticsComponent = DiagnosticsComponent;
