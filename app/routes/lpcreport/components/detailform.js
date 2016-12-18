System.register(['@angular/core', '@angular/forms', 'angular2-toaster/angular2-toaster', '../services/lpcreport', '../../references/services/references', '../../../shared/services/session'], function(exports_1, context_1) {
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
    var core_1, forms_1, angular2_toaster_1, lpcreport_1, references_1, session_1;
    var DetailsListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (angular2_toaster_1_1) {
                angular2_toaster_1 = angular2_toaster_1_1;
            },
            function (lpcreport_1_1) {
                lpcreport_1 = lpcreport_1_1;
            },
            function (references_1_1) {
                references_1 = references_1_1;
            },
            function (session_1_1) {
                session_1 = session_1_1;
            }],
        execute: function() {
            DetailsListComponent = (function () {
                function DetailsListComponent(toasterService, builder, session, 
                    // private location: Location,
                    referenceService, lpcReportService) {
                    this.toasterService = toasterService;
                    this.builder = builder;
                    this.session = session;
                    this.referenceService = referenceService;
                    this.lpcReportService = lpcReportService;
                    this.submitted = false;
                    this.formInitted = false;
                    this.form = this.builder.group({
                        'name': ['', forms_1.Validators.compose([forms_1.Validators.required])],
                        'objectType': ['', forms_1.Validators.compose([forms_1.Validators.required])],
                        'architect': ['', forms_1.Validators.compose([forms_1.Validators.required])],
                        'style': ['', forms_1.Validators.compose([forms_1.Validators.required])],
                        'dateDesignated': ['', forms_1.Validators.compose([forms_1.Validators.required])],
                        'street': ['', forms_1.Validators.compose([forms_1.Validators.required])],
                        'borough': ['', forms_1.Validators.compose([forms_1.Validators.required])]
                    });
                    this.name = this.form.controls['name'];
                    this.objectType = this.form.controls['objectType'];
                    this.architect = this.form.controls['architect'];
                    this.style = this.form.controls['style'];
                    this.dateDesignated = this.form.controls['dateDesignated'];
                    this.street = this.form.controls['street'];
                    this.borough = this.form.controls['borough'];
                }
                ;
                DetailsListComponent.prototype.getObjectTypes = function () {
                    var _this = this;
                    this.referenceService.getObjectTypes().subscribe(function (data) {
                        _this.objectTypes = data;
                        _this.session.set('objectTypes', data);
                    }, function (err) { return _this.pop(err, 'Error', 'error'); });
                    return this.session.get('objectTypes');
                };
                DetailsListComponent.prototype.getBoroughs = function () {
                    var _this = this;
                    this.referenceService.getBoroughs().subscribe(function (data) {
                        _this.boroughs = data;
                        _this.session.set('boroughs', data);
                    }, function (err) { return _this.pop(err, 'Error', 'error'); });
                    return this.session.get('boroughs');
                };
                DetailsListComponent.prototype.ngOnInit = function () {
                    var objectTypes = this.session.get('objectTypes');
                    this.objectTypes = (objectTypes) ? objectTypes : this.getObjectTypes();
                    var boroughs = this.session.get('boroughs');
                    this.boroughs = (boroughs) ? boroughs : this.getBoroughs();
                };
                ;
                DetailsListComponent.prototype.ngAfterViewChecked = function () {
                    if (this.details && !this.formInitted) {
                        this.form.patchValue(this.details, { onlySelf: true });
                        this.formInitted = true;
                    }
                };
                ;
                // TOSATER METHOD
                DetailsListComponent.prototype.pop = function (message, title, type) {
                    this.toaster = {
                        type: type || 'info',
                        title: title || '',
                        text: message
                    };
                    this.toasterService.pop(this.toaster.type, this.toaster.title, this.toaster.text);
                };
                ;
                DetailsListComponent.prototype.getDateFormatted = function (date) {
                    var mm = date.getMonth() + 1; // getMonth() is zero-based
                    var dd = date.getDate();
                    return [(mm.length === 2 && '0') + mm, (dd.length === 2 && '0') + dd, date.getFullYear()].join('/'); // padding
                };
                ;
                DetailsListComponent.prototype.onSubmit = function (values) {
                    var _this = this;
                    this.submitted = true;
                    if (this.form.valid) {
                        var details_1 = values;
                        details_1.id = this.details.id;
                        // console.log(values);
                        // Submit http request
                        this.lpcReportService.putLPCReport(this.details.id, values)
                            .subscribe(function (res) {
                            // console.log(res);
                            _this.pop(details_1.name + ' updated', '', 'success');
                            // this.location.back();
                        }, function (err) { return _this.pop(err, 'Error', 'error'); });
                    }
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Object)
                ], DetailsListComponent.prototype, "details", void 0);
                DetailsListComponent = __decorate([
                    core_1.Component({
                        // moduleId: module.id,
                        selector: 'details-list',
                        templateUrl: 'app/routes/lpcreport/components/detailsList.html',
                        //When using OnPush detectors, then the framework will check an OnPush 
                        //component when any of its input properties changes, when it fires 
                        //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
                        changeDetection: core_1.ChangeDetectionStrategy.OnPush
                    }), 
                    __metadata('design:paramtypes', [angular2_toaster_1.ToasterService, forms_1.FormBuilder, session_1.SessionService, references_1.ReferencesService, lpcreport_1.LPCReportService])
                ], DetailsListComponent);
                return DetailsListComponent;
            }());
            exports_1("DetailsListComponent", DetailsListComponent);
            ;
        }
    }
});
