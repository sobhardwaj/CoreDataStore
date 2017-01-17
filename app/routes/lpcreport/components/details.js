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
                /*overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal*/
                function DetailsComponent(lpcReportService, route) {
                    var _this = this;
                    this.lpcReportService = lpcReportService;
                    this.route = route;
                    this.landmarkProperties = [];
                    this.sub = null;
                    // ng2Table
                    this.ng2TableData = [];
                    this.rows = [];
                    this.columns = [
                        { title: 'Id', name: 'id', sort: 'asc' },
                        { title: 'BLL', name: 'bbl' },
                        { title: 'BIN_NUMBER', name: 'binNumber' },
                        { title: 'BoroughID', name: 'boroughId' },
                        { title: 'BLOCK', name: 'block' },
                        { title: 'LOT', name: 'lot' },
                        { title: 'LP_NUMBER', name: 'lpNumber' },
                        { title: 'LM_NAME', name: 'name' },
                        { title: 'PLUTO_ADDR', name: 'designatedAddress' },
                        { title: 'DESIG_ADDR', name: 'plutoAddress' }
                    ];
                    this.page = 1;
                    this.itemsPerPage = 10;
                    this.maxSize = 5;
                    this.numPages = 1;
                    this.length = 0;
                    this.config = {
                        paging: true,
                        sorting: { columns: this.columns },
                        // filtering: { filterString: '' },
                        className: ['table-striped', 'table-bordered']
                    };
                    // overlay.defaultViewContainer = vcRef;
                    this.sub = this.route.params.subscribe(function (params) {
                        var id = +params['id'];
                        // console.log(id);
                        _this.lpcReportService.getLPCReport(id).subscribe(function (data) {
                            _this.details = data;
                            _this.latitude = data.latitude;
                            _this.longitude = data.longitude;
                            _this.title = data.name;
                            _this.lpcReportService.getLandmarkProperties(_this.details.lpNumber).subscribe(function (data) {
                                _this.landmarkProperties = data || [];
                                _this.ng2TableData = _this.landmarkProperties;
                                _this.length = _this.landmarkProperties.length;
                            }, function (err) { return console.log(err); });
                        }, function (err) { return console.log(err); });
                    });
                }
                DetailsComponent.prototype.ngOnInit = function () {
                    this.onChangeTable(this.config);
                };
                DetailsComponent.prototype.ngOnDestroy = function () {
                    this.sub.unsubscribe();
                };
                DetailsComponent.prototype.changePage = function (page, data) {
                    if (data === void 0) { data = this.ng2TableData; }
                    var start = (page.page - 1) * page.itemsPerPage;
                    var end = page.itemsPerPage > -1 ? (start + page.itemsPerPage) : data.length;
                    return (data && data.length) ? data.slice(start, end) : data;
                };
                DetailsComponent.prototype.changeSort = function (data, config) {
                    if (!config.sorting) {
                        return data;
                    }
                    var columns = this.config.sorting.columns || [];
                    var columnName = void 0;
                    var sort = void 0;
                    for (var i = 0; i < columns.length; i++) {
                        if (columns[i].sort !== '' && columns[i].sort !== false) {
                            columnName = columns[i].name;
                            sort = columns[i].sort;
                        }
                    }
                    if (!columnName) {
                        return data;
                    }
                    // simple sorting
                    if (data) {
                        return data.sort(function (previous, current) {
                            if (previous[columnName] > current[columnName]) {
                                return sort === 'desc' ? -1 : 1;
                            }
                            else if (previous[columnName] < current[columnName]) {
                                return sort === 'asc' ? -1 : 1;
                            }
                            return 0;
                        });
                    }
                    else {
                        return data;
                    }
                };
                DetailsComponent.prototype.changeFilter = function (data, config) {
                    var _this = this;
                    var filteredData = data;
                    this.columns.forEach(function (column) {
                        if (column.filtering) {
                            filteredData = filteredData.filter(function (item) {
                                return item[column.name].match(column.filtering.filterString);
                            });
                        }
                    });
                    if (!config.filtering) {
                        return filteredData;
                    }
                    if (config.filtering.columnName) {
                        return filteredData.filter(function (item) {
                            return item[config.filtering.columnName].match(_this.config.filtering.filterString);
                        });
                    }
                    var tempArray = [];
                    filteredData.forEach(function (item) {
                        var flag = false;
                        _this.columns.forEach(function (column) {
                            if (item[column.name].toString().match(_this.config.filtering.filterString)) {
                                flag = true;
                            }
                        });
                        if (flag) {
                            tempArray.push(item);
                        }
                    });
                    filteredData = tempArray;
                    return filteredData;
                };
                DetailsComponent.prototype.onChangeTable = function (config, page) {
                    if (page === void 0) { page = { page: this.page, itemsPerPage: this.itemsPerPage }; }
                    if (config.filtering) {
                        Object.assign(this.config.filtering, config.filtering);
                    }
                    if (config.sorting) {
                        Object.assign(this.config.sorting, config.sorting);
                    }
                    var filteredData = this.changeFilter(this.ng2TableData, this.config);
                    var sortedData = this.changeSort(filteredData, this.config);
                    this.rows = page && config.paging ? this.changePage(page, sortedData) : sortedData;
                    this.length = (sortedData && sortedData.length) ? sortedData.length : 0;
                };
                DetailsComponent.prototype.onCellClick = function (data) {
                    console.log(data);
                };
                DetailsComponent = __decorate([
                    core_1.Component({
                        selector: 'properties-details',
                        templateUrl: 'app/routes/lpcreport/components/details.html',
                        providers: [lpcreport_1.LPCReportService, references_1.ReferencesService],
                        encapsulation: core_1.ViewEncapsulation.None
                    }), 
                    __metadata('design:paramtypes', [lpcreport_1.LPCReportService, router_1.ActivatedRoute])
                ], DetailsComponent);
                return DetailsComponent;
            }());
            exports_1("DetailsComponent", DetailsComponent);
        }
    }
});
