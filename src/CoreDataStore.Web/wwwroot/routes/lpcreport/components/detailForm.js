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
var moment = require("moment");
var core_1 = require("@angular/core");
// import { Location } from '@angular/common';
var forms_1 = require("@angular/forms");
var ng2_toastr_1 = require("ng2-toastr/ng2-toastr");
var lpcreport_1 = require("../services/lpcreport");
var references_1 = require("../../references/services/references");
var session_1 = require("../../../shared/services/session");
var DetailFormComponent = /** @class */ (function () {
    function DetailFormComponent(toastr, vRef, builder, session, 
    // private location: Location,
    referenceService, lpcReportService) {
        this.toastr = toastr;
        this.builder = builder;
        this.session = session;
        this.referenceService = referenceService;
        this.lpcReportService = lpcReportService;
        this.submitted = false;
        this.formInitted = false;
        this.isCollapsed = true;
        this.toastr.setRootViewContainerRef(vRef);
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
        console.log(this.dateDesignated);
        // this.form.controls['dateDesignated'].setValue(this.dateDesignated);
        this.street = this.form.controls['street'];
        this.borough = this.form.controls['borough'];
        if (window.innerWidth < 768) {
            this.isMobile = true;
        }
        else {
            this.isMobile = false;
        }
    }
    ;
    DetailFormComponent.prototype.getObjectTypes = function () {
        var _this = this;
        this.referenceService.getObjectTypes().subscribe(function (data) {
            _this.objectTypes = data;
            _this.session.set('objectTypes', data);
        }, function (err) { return _this.toastr.error('Error', 'error'); });
        return this.session.get('objectTypes');
    };
    DetailFormComponent.prototype.getBoroughs = function () {
        var _this = this;
        this.referenceService.getBoroughs().subscribe(function (data) {
            _this.boroughs = data;
            _this.session.set('boroughs', data);
        }, function (err) { return _this.toastr.error('Error', 'error'); });
        return this.session.get('boroughs');
    };
    DetailFormComponent.prototype.ngOnInit = function () {
        var objectTypes = this.session.get('objectTypes');
        this.objectTypes = (objectTypes) ? objectTypes : this.getObjectTypes();
        var boroughs = this.session.get('boroughs');
        this.boroughs = (boroughs) ? boroughs : this.getBoroughs();
    };
    ;
    DetailFormComponent.prototype.ngAfterViewChecked = function () {
        if (this.details && !this.formInitted) {
            this.form.patchValue(this.details, { onlySelf: true });
            this.formInitted = true;
            this.dt = moment(this.details.dateDesignated);
            this.form.controls['dateDesignated'].setValue(this.dt.format('YYYY-MM-DD'));
        }
    };
    ;
    DetailFormComponent.prototype.getDateFormatted = function (date) {
        var mm = date.getMonth() + 1; // getMonth() is zero-based
        var dd = date.getDate();
        return [(mm.length === 2 && '0') + mm, (dd.length === 2 && '0') + dd, date.getFullYear()].join('/'); // padding
    };
    ;
    DetailFormComponent.prototype.dateChanged = function (date) {
        var dt = moment(date);
        if (dt.isValid()) {
            this.form.controls['dateDesignated'].setValue(dt.format('YYYY-MM-DD'));
        }
    };
    DetailFormComponent.prototype.onSubmit = function (values) {
        var _this = this;
        this.submitted = true;
        if (this.form.valid) {
            var details_1 = values;
            details_1.id = this.details.id;
            // console.log(values);
            // Submit http request
            this.lpcReportService.putLPCReport(this.details.id, values)
                .subscribe(function (res) {
                var errors = res.json() || [];
                if (errors.length) {
                    errors.forEach(function (err) {
                        _this.toastr.error(err.errorMessage, 'Error');
                    });
                }
                else {
                    _this.toastr.success(details_1.name + ' updated', 'Success');
                }
            }, function (err) { return _this.toastr.error('Error', 'error'); });
        }
    };
    DetailFormComponent.prototype.onResize = function (event) {
        if (window.innerWidth < 768) {
            this.isMobile = true;
        }
        else {
            this.isMobile = false;
        }
    };
    var _a, _b, _c;
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object)
    ], DetailFormComponent.prototype, "details", void 0);
    DetailFormComponent = __decorate([
        core_1.Component({
            selector: 'detail-form',
            templateUrl: 'app/routes/lpcreport/components/detailForm.html',
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof ng2_toastr_1.ToastsManager !== "undefined" && ng2_toastr_1.ToastsManager) === "function" ? _a : Object, typeof (_b = typeof core_1.ViewContainerRef !== "undefined" && core_1.ViewContainerRef) === "function" ? _b : Object, typeof (_c = typeof forms_1.FormBuilder !== "undefined" && forms_1.FormBuilder) === "function" ? _c : Object, session_1.SessionService,
            references_1.ReferencesService,
            lpcreport_1.LPCReportService])
    ], DetailFormComponent);
    return DetailFormComponent;
}());
exports.DetailFormComponent = DetailFormComponent;
;
//# sourceMappingURL=detailForm.js.map