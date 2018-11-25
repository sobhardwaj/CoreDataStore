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
var lpcreport_1 = require("../services/lpcreport");
var pluto_1 = require("../services/pluto");
var references_1 = require("../../references/services/references");
var DetailsComponent = /** @class */ (function () {
    /*@Inject(ActivatedRoute) */
    /*overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal*/
    function DetailsComponent(lpcReportService, plutoService, elem, route) {
        var _this = this;
        this.lpcReportService = lpcReportService;
        this.plutoService = plutoService;
        this.elem = elem;
        this.route = route;
        this.landmarkProperties = [];
        this.mapMarkers = [];
        this.sub = null;
        this.columnsLandmarks = [
            { headerName: 'Id', field: 'id', width: 50 },
            { headerName: 'Street', field: 'street', width: 200, editable: true, sort: 'asc' },
            { headerName: 'Address', field: 'designatedAddress', editable: true, width: 180 },
            { headerName: 'Block', field: 'block', editable: true, width: 100 },
            { headerName: 'Lot', field: 'lot', editable: true, width: 80 },
            { headerName: 'Building', field: 'isBuilding', editable: true, width: 80 },
            { headerName: 'BLL', field: 'bbl', editable: true, width: 120 },
            { headerName: 'BIN', field: 'binNumber', editable: true, width: 120 },
            { headerName: 'PLUTO Address', field: 'plutoAddress', editable: true, width: 180 },
            { headerName: 'LandMark', field: 'name', editable: true, width: 200 },
            { headerName: 'LP Number', field: 'lpNumber', editable: true, width: 150 },
            { headerName: 'Type', field: 'objectType', editable: true, width: 125 },
            { headerName: 'Borough', field: 'boroughId', editable: true, width: 75 }
        ];
        this.columnsPluto = [
            { headerName: 'Id', field: 'id', width: 50 },
            { headerName: 'Address', field: 'address', editable: true, width: 200 },
            { headerName: 'Borough', field: 'borough', width: 80, editable: true },
            { headerName: 'Block', field: 'block', editable: true, width: 50 },
            { headerName: 'HistDist', field: 'histDist', editable: true, width: 200 },
            { headerName: 'Latitude', field: 'latitude', editable: true, width: 80 },
            { headerName: 'Longitude', field: 'longitude', editable: true, width: 80 },
            { headerName: 'Lot', field: 'lot', editable: true, width: 50 },
            { headerName: 'lotArea', field: 'lotArea', editable: true, width: 80 },
            { headerName: 'numBldgs', field: 'numBldgs', editable: true, width: 80 },
            { headerName: 'Owner Name', field: 'ownerName', editable: true, width: 200 },
            { headerName: 'xCoord', field: 'xCoord', editable: true, width: 70 },
            { headerName: 'yCoord', field: 'yCoord', editable: true, width: 70 },
            { headerName: 'year', field: 'yearBuilt', editable: true, width: 50 }
        ];
        // overlay.defaultViewContainer = vcRef;
        this.getGridData();
        // ag-grid gridOptionsLandmarks
        this.gridOptionsLandmarks = {
            columnDefs: this.columnsLandmarks,
            rowData: null,
            // pagination: true,
            // paginationAutoPageSize: true,
            // paginationPageSize: 100,
            // paginationStartPage: 1,
            enableColResize: true,
            // enableSorting: true,
            // enableFilter: true,
            gridReady: function (params) {
                //   params.api.setWidthAndHeight('100%','100%');
                //   params.api.sizeColumnsToFit();
                //   this.$win.on(this.resizeEvent, () => {
                //     setTimeout(() => { params.api.sizeColumnsToFit(); });
                //   });
            }
        };
        // ag-grid gridOptionsLandmarks
        this.gridOptionsPluto = {
            columnDefs: this.columnsPluto,
            rowData: null,
            // pagination: true,
            // paginationAutoPageSize: true,
            // paginationPageSize: 100,
            // paginationStartPage: 1,
            enableColResize: true,
        };
        if (window.innerWidth < 768) {
            this.isMobile = true;
        }
        else {
            this.isMobile = false;
        }
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (pos) {
                _this.userPos = pos;
            });
        }
    }
    DetailsComponent.prototype.ngOnInit = function () {
        $(window).scrollTop(0, 0);
    };
    DetailsComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    DetailsComponent.prototype.changePage = function (page) { };
    DetailsComponent.prototype.setWidthAndHeight = function (divId, width, height) {
        if (divId === void 0) { divId = '#ag-gridLandmarks'; }
        if (width === void 0) { width = '100%'; }
        if (height === void 0) { height = '100%'; }
        var grid = this.elem.nativeElement.querySelector(divId);
        grid.style.width = width;
        grid.style.height = height;
        this.gridOptionsLandmarks.api.doLayout();
    };
    DetailsComponent.prototype.getGridData = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            var id = +params['id'];
            // console.log(id);
            _this.lpcReportService.getLPCReport(id).subscribe(function (data) {
                _this.details = data;
                _this.title = data.name;
                _this.lpcReportService.getLandmarkProperties(_this.details.lpNumber).subscribe(function (data) {
                    _this.landmarkProperties = data || [];
                    if (_this.landmarkProperties.length > 1) {
                        _this.setWidthAndHeight('#ag-gridLandmarks', '100%', '100%');
                    }
                    else {
                        _this.setWidthAndHeight('#ag-gridLandmarks', '100%', '70px');
                    }
                    _this.gridOptionsLandmarks.api.setRowData(_this.landmarkProperties);
                }, function (err) { return console.log(err); });
                _this.plutoService.getMapMarkers(_this.details.lpNumber).subscribe(function (data) {
                    _this.mapMarkers = data;
                    if (_this.mapMarkers.length > 1) {
                        _this.setWidthAndHeight('#ag-gridPluto', '100%', '100%');
                    }
                    else {
                        _this.setWidthAndHeight('#ag-gridPluto', '100%', '70px');
                    }
                    _this.gridOptionsPluto.api.setRowData(_this.mapMarkers);
                });
            }, function (err) { return console.log(err); });
        });
    };
    DetailsComponent.prototype.onResize = function (event) {
        if (window.innerWidth < 768) {
            this.isMobile = true;
        }
        else {
            this.isMobile = false;
        }
        this.getGridData();
    };
    var _a, _b;
    DetailsComponent = __decorate([
        core_1.Component({
            selector: 'properties-details',
            templateUrl: 'app/routes/lpcreport/components/details.html',
            providers: [lpcreport_1.LPCReportService, references_1.ReferencesService, pluto_1.PlutoService],
            encapsulation: core_1.ViewEncapsulation.None
        }),
        __metadata("design:paramtypes", [lpcreport_1.LPCReportService,
            pluto_1.PlutoService, typeof (_a = typeof core_1.ElementRef !== "undefined" && core_1.ElementRef) === "function" ? _a : Object, typeof (_b = typeof router_1.ActivatedRoute !== "undefined" && router_1.ActivatedRoute) === "function" ? _b : Object])
    ], DetailsComponent);
    return DetailsComponent;
}());
exports.DetailsComponent = DetailsComponent;
//# sourceMappingURL=details.js.map