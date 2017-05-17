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
var session_1 = require("../../../shared/services/session");
var references_1 = require("../services/references");
var lpcreport_1 = require("../../lpcreport/services/lpcreport");
var ReferencesComponent = (function () {
    // displayMode: DisplayModeEnum;
    // displayModeEnum = DisplayModeEnum;
    function ReferencesComponent(session, referenceService, lpcReportService) {
        this.session = session;
        this.referenceService = referenceService;
        this.lpcReportService = lpcReportService;
        this.ignorePageChangedEvent = false;
        this.page = 1;
        this.limit = 20;
        this.perPage = [10, 20, 50, 100];
        this.totalItems = 100;
        this.fromItem = 1;
        this.toItem = 20;
        this.boroughs = [];
        this.objectTypes = [];
        this.properties = []; // LPCReports list;
        this.filteredReference = [];
        var page = this.session.get('page');
        this.page = (parseInt(page, 10) > 0) ? page : 1;
    }
    ReferencesComponent.prototype.ngOnInit = function () {
        this.title = 'LPC Reports';
        this.getObjectTypes();
        this.getBoroughs();
        var objectType = this.session.get('objectType');
        this.objectType = (objectType) ? objectType : '';
        var borough = this.session.get('borough');
        this.borough = (borough) ? borough : '';
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
    };
    ReferencesComponent.prototype.getLPCReports = function (page, limit, borough, objectType) {
        var _this = this;
        this.lpcReportService.getLPCReports(page, limit, borough, objectType).subscribe(function (data) {
            _this.properties = _this.filteredReference = data.reports;
            _this.totalItems = data.total;
            _this.scrollTop();
            _this.objectType = objectType;
            _this.borough = borough;
            _this.page = page;
            _this.fromItem = ((page - 1) * limit) + 1;
            _this.toItem = (_this.totalItems < (page * limit)) ? _this.totalItems : (page * limit);
        }, function () { return console.log('done loading getLPCReports'); });
    };
    ReferencesComponent.prototype.getObjectTypes = function () {
        var _this = this;
        this.referenceService.getObjectTypes().subscribe(function (data) { _this.objectTypes = data; }, function (err) { return console.error(err); });
    };
    ReferencesComponent.prototype.getBoroughs = function () {
        var _this = this;
        this.referenceService.getBoroughs().subscribe(function (data) { _this.boroughs = data; }, function (err) { return console.error(err); });
    };
    /*changeDisplayMode(mode: DisplayModeEnum) {
        this.displayMode = mode;
    }*/
    ReferencesComponent.prototype.boroughChanged = function (data) {
        // console.log(data);
        this.borough = data;
        this.session.set('borough', data);
        this.page = 1;
        this.session.set('page', this.page);
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
    };
    ReferencesComponent.prototype.objectTypeChanged = function (data) {
        // console.log(data);
        this.objectType = data;
        this.session.set('objectType', data);
        this.page = 1;
        this.session.set('page', this.page);
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
    };
    ReferencesComponent.prototype.pageChanged = function (event) {
        if (!this.ignorePageChangedEvent) {
            this.page = event.page;
            this.session.set('page', this.page);
            this.getLPCReports(event.page, this.limit, this.borough, this.objectType);
        }
        this.ignorePageChangedEvent = false;
    };
    ReferencesComponent.prototype.perPageChanged = function (limit) {
        limit = parseInt(limit, 10);
        this.ignorePageChangedEvent = this.limit < limit; //Little workaround for paginator last page cornercase
        this.page = 1;
        this.limit = limit;
        this.session.set('page', this.page);
        this.getLPCReports(1, limit, this.borough, this.objectType);
    };
    ReferencesComponent.prototype.scrollTop = function () {
        $(window).scrollTop(0, 0);
    };
    return ReferencesComponent;
}());
ReferencesComponent = __decorate([
    core_1.Component({
        selector: 'properties',
        templateUrl: 'app/routes/references/components/references.html',
        providers: [references_1.ReferencesService, lpcreport_1.LPCReportService, session_1.SessionService]
    }),
    __metadata("design:paramtypes", [session_1.SessionService,
        references_1.ReferencesService,
        lpcreport_1.LPCReportService])
], ReferencesComponent);
exports.ReferencesComponent = ReferencesComponent;
/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/
