System.register(['@angular/core', '@angular/router', '../services/lpcreport', '../../references/services/references'], function(exports_1, context_1) {
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
    var core_1, router_1, lpcreport_1, references_1;
    var DetailsComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (lpcreport_1_1) {
                lpcreport_1 = lpcreport_1_1;
            },
            function (references_1_1) {
                references_1 = references_1_1;
            }],
        execute: function() {
            DetailsComponent = (function () {
                /*@Inject(ActivatedRoute) */
                function DetailsComponent(lpcReportService, route) {
                    this.lpcReportService = lpcReportService;
                    this.route = route;
                    this.landmarkProperties = null;
                    this.sub = null;
                    // overlay.defaultViewContainer = vcRef;
                }
                DetailsComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.sub = this.route.params.subscribe(function (params) {
                        var id = +params['id'];
                        // console.log(id);
                        _this.lpcReportService.getLPCReport(id).subscribe(function (data) {
                            _this.details = data;
                            _this.latitude = data.latitude;
                            _this.longitude = data.longitude;
                            _this.title = data.name;
                            _this.lpcReportService.getLandmarkProperties(_this.details.lpNumber).subscribe(function (data) { _this.landmarkProperties = data; }, function () { return console.log('done loading getLandmarkProperties'); });
                        });
                    });
                };
                DetailsComponent.prototype.ngOnDestroy = function () {
                    this.sub.unsubscribe();
                };
                DetailsComponent = __decorate([
                    core_1.Component({
                        selector: 'properties-details',
                        templateUrl: 'app/routes/lpcreport/components/details.html',
                        providers: [lpcreport_1.LPCReportService, references_1.ReferencesService]
                    }), 
                    __metadata('design:paramtypes', [lpcreport_1.LPCReportService, router_1.ActivatedRoute])
                ], DetailsComponent);
                return DetailsComponent;
            }());
            exports_1("DetailsComponent", DetailsComponent);
        }
    }
});
