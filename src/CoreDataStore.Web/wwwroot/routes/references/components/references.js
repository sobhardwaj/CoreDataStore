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
var ReferencesComponent = /** @class */ (function () {
    // displayMode: DisplayModeEnum;
    // displayModeEnum = DisplayModeEnum;
    function ReferencesComponent(session, referenceService, lpcReportService, changRef) {
        this.session = session;
        this.referenceService = referenceService;
        this.lpcReportService = lpcReportService;
        this.changRef = changRef;
        this.ignorePageChangedEvent = false;
        this.page = 1;
        this.limit = 20;
        this.perPage = [10, 20, 50, 100];
        this.totalItems = 100;
        this.fromItem = 1;
        this.toItem = 20;
        this.boroughs = [];
        this.objectTypes = [];
        this.neighborhoods = [];
        this.tempNeighbors = [];
        this.properties = []; // LPCReports list;
        this.filteredReference = [];
        this.scrollPosition = 0;
        this.isMobile = false;
        this.disableNeighbor = true;
        var page = this.session.get('page');
        this.page = (parseInt(page, 10) > 0) ? page : 1;
    }
    ReferencesComponent.prototype.ngOnInit = function () {
        this.title = 'LPC Reports';
        this.getObjectTypes();
        this.getBoroughs();
        this.getNeighborhoods();
        if (window.innerWidth < 768) {
            this.isMobile = true;
        }
        else {
            this.isMobile = false;
        }
        var objectType = this.session.get('objectType');
        this.objectType = (objectType) ? objectType : '';
        var borough = this.session.get('borough');
        this.borough = (borough) ? borough : '';
        var neighborhood = this.session.get('neighborhood');
        this.neighborhood = (neighborhood) ? neighborhood : '';
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
    };
    ReferencesComponent.prototype.getLPCReports = function (page, limit, borough, objectType, neighborhood) {
        var _this = this;
        this.lpcReportService.getLPCReports(page, limit, borough, objectType, neighborhood).subscribe(function (data) {
            _this.properties = _this.filteredReference = data.reports;
            _this.totalItems = data.total;
            if (!_this.isMobile)
                _this.scrollTop();
            _this.objectType = objectType;
            _this.borough = borough;
            _this.neighborhood = neighborhood;
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
        this.referenceService.getBoroughs().subscribe(function (data) { _this.boroughs = data; console.log(data); }, function (err) { return console.error(err); });
    };
    ReferencesComponent.prototype.getNeighborhoods = function () {
        var _this = this;
        this.referenceService.getNeighborhoods().subscribe(function (data) {
            _this.tempNeighbors = data;
            _this.tempNeighbors.map(function (temp) {
                _this.neighborhoods.push(temp.name);
            });
            console.log(_this.neighborhoods);
        }, function (err) { return console.error(err); });
    };
    /*changeDisplayMode(mode: DisplayModeEnum) {
        this.displayMode = mode;
    }*/
    ReferencesComponent.prototype.boroughChanged = function (data) {
        var _this = this;
        // console.log(data);
        this.borough = data;
        this.neighborhoods = [];
        this.tempNeighbors.map(function (temp) {
            if (temp.location == _this.borough) {
                _this.neighborhoods.push(temp.name);
                _this.neighborhood = "";
            }
            if (_this.borough == "Manhattan" && temp.location.indexOf("Manhattan") >= 0) {
                _this.neighborhoods.push(temp.name);
                _this.neighborhood = "";
            }
        });
        this.disableNeighbor = false;
        if (data == "") {
            this.neighborhoods = [];
            this.neighborhood = "";
            this.disableNeighbor = true;
        }
        this.changRef.detectChanges();
        this.session.set('borough', data);
        this.page = 1;
        this.session.set('page', this.page);
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
    };
    ReferencesComponent.prototype.objectTypeChanged = function (data) {
        // console.log(data);
        this.objectType = data;
        this.session.set('objectType', data);
        this.page = 1;
        this.session.set('page', this.page);
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
    };
    ReferencesComponent.prototype.neighborhoodChanged = function (data) {
        // console.log(data);
        this.neighborhood = data;
        this.session.set('neighborhood', data);
        this.page = 1;
        this.session.set('page', this.page);
        this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
    };
    ReferencesComponent.prototype.pageChanged = function (event) {
        if (!this.ignorePageChangedEvent) {
            this.page = event.page;
            this.session.set('page', this.page);
            this.getLPCReports(event.page, this.limit, this.borough, this.objectType, this.neighborhood);
        }
        this.ignorePageChangedEvent = false;
    };
    ReferencesComponent.prototype.perPageChanged = function (limit) {
        limit = parseInt(limit, 10);
        this.ignorePageChangedEvent = this.limit < limit; //Little workaround for paginator last page cornercase
        this.page = 1;
        this.limit = limit;
        this.session.set('page', this.page);
        this.getLPCReports(1, limit, this.borough, this.objectType, this.neighborhood);
    };
    ReferencesComponent.prototype.scrollTop = function () {
        $(window).scrollTop(0, 0);
    };
    ReferencesComponent.prototype.onResize = function (event) {
        if (window.innerWidth < 768) {
            this.isMobile = true;
        }
        else {
            this.isMobile = false;
        }
    };
    ReferencesComponent.prototype.onScroll = function (event) {
        if (this.isMobile == true && $(window).scrollTop() + $(window).height() == $(document).height()) {
            this.session.set('page', this.page);
            this.limit += 20;
            this.scrollPosition = $(document).height();
            this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
        }
    };
    var _a;
    ReferencesComponent = __decorate([
        core_1.Component({
            selector: 'properties',
            templateUrl: 'app/routes/references/components/references.html',
            providers: [references_1.ReferencesService, lpcreport_1.LPCReportService, session_1.SessionService]
        }),
        __metadata("design:paramtypes", [session_1.SessionService,
            references_1.ReferencesService,
            lpcreport_1.LPCReportService, typeof (_a = typeof core_1.ChangeDetectorRef !== "undefined" && core_1.ChangeDetectorRef) === "function" ? _a : Object])
    ], ReferencesComponent);
    return ReferencesComponent;
}());
exports.ReferencesComponent = ReferencesComponent;
/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/
// import { SessionService } from '../../../shared/services/session';
// import { ReferencesService } from '../services/references';
// import { LPCReportService } from '../../lpcreport/services/lpcreport';
// import { ReferencesListComponent } from './referencesList';
// import { FilterSelectboxComponent } from './filterSelectbox';
// @Component({
//   selector: 'properties',
//   templateUrl: 'app/routes/references/components/references.html',
//   providers: [ReferencesService, LPCReportService, SessionService]
// })
// export class ReferencesComponent implements OnInit {
//   title: string;
//   borough: string;
//   objectType: string;
//   ignorePageChangedEvent: boolean = false;
//   page: number = 1;
//   limit: number = 20;
//   perPage: any[] = [10, 20, 50, 100];
//   totalItems: number = 100;
//   fromItem: number = 1;
//   toItem: number = 20;
//   boroughs: string[] = [];
//   objectTypes: string[] = [];
//   properties: any[] = []; // LPCReports list;
//   filteredReference: any[] = [];
//   scrollPosition: number = 0;
//   isMobile: boolean = false;
//   // displayMode: DisplayModeEnum;
//   // displayModeEnum = DisplayModeEnum;
//   constructor(
//     private session: SessionService,
//     private referenceService: ReferencesService,
//     private lpcReportService: LPCReportService) {
//     let page = this.session.get('page');
//     this.page = (parseInt(page, 10) > 0) ? page : 1;
//   }
//   ngOnInit() {
//     this.title = 'LPC Reports';
//     this.getObjectTypes();
//     this.getBoroughs();
//     if(window.innerWidth < 768) {
//       this.isMobile = true;
//     } else {
//       this.isMobile = false;
//     }
//     let objectType = this.session.get('objectType');
//     this.objectType = (objectType) ? objectType : '';
//     let borough = this.session.get('borough');
//     this.borough = (borough) ? borough : '';
//     this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
//   }
//   getLPCReports(page, limit, borough, objectType) {
//     this.lpcReportService.getLPCReports(page, limit, borough, objectType).subscribe(
//       data => {
//         this.properties = this.filteredReference = data.reports;
//         this.totalItems = data.total;
//         if(!this.isMobile)
//           this.scrollTop();
//         this.objectType = objectType;
//         this.borough = borough;
//         this.page = page;
//         this.fromItem = ((page - 1) * limit) + 1;
//         this.toItem = (this.totalItems < (page * limit)) ? this.totalItems : (page * limit);
//       },
//       () => console.log('done loading getLPCReports')
//     );
//   }
//   getObjectTypes() {
//     this.referenceService.getObjectTypes().subscribe(
//       data => { this.objectTypes = data; },
//       err => console.error(err)
//     );
//   }
//   getBoroughs() {
//     this.referenceService.getBoroughs().subscribe(
//       data => { this.boroughs = data; },
//       err => console.error(err)
//     );
//   }
//   /*changeDisplayMode(mode: DisplayModeEnum) {
//       this.displayMode = mode;
//   }*/
//   boroughChanged(data: string) {
//     // console.log(data);
//     this.borough = data;
//     this.session.set('borough', data);
//     this.page = 1;
//     this.session.set('page', this.page);
//     this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
//   }
//   objectTypeChanged(data: string) {
//     // console.log(data);
//     this.objectType = data;
//     this.session.set('objectType', data);
//     this.page = 1;
//     this.session.set('page', this.page);
//     this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
//   }
//   public pageChanged(event: any) {
//     if (!this.ignorePageChangedEvent) {
//       this.page = event.page;
//       this.session.set('page', this.page);
//       this.getLPCReports(event.page, this.limit, this.borough, this.objectType);
//     }
//     this.ignorePageChangedEvent = false;
//   }
//   public perPageChanged(limit: any) {
//     limit = parseInt(limit, 10);
//     this.ignorePageChangedEvent =  this.limit < limit; //Little workaround for paginator last page cornercase
//     this.page = 1;
//     this.limit = limit;
//     this.session.set('page', this.page);
//     this.getLPCReports(1, limit, this.borough, this.objectType);
//   }
//   private scrollTop() {
//     $(window).scrollTop(0, 0);
//   }
//   private onResize(event) {
//     if(window.innerWidth < 768) {
//       this.isMobile = true;
//     } else {
//       this.isMobile = false;
//     }
//   }
//   private onScroll(event) {
//     if(this.isMobile == true && $(window).scrollTop() + $(window).height() == $(document).height()) {
//       this.session.set('page', this.page);
//       this.limit += 20;
//       this.scrollPosition = $(document).height();
//       this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
//     }
//   }
// }
// /*
// enum DisplayModeEnum {
//   Card = 0,
//   Grid = 1,
//   Map = 2
// }
// */
//# sourceMappingURL=references.js.map