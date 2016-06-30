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
var core_1 = require('@angular/core');
var common_1 = require('@angular/common');
var ng2_select_1 = require('ng2-select');
var FilterSelectboxComponent = (function () {
    function FilterSelectboxComponent() {
        this.model = { filter: null };
        this.items = [];
        this.changed = new core_1.EventEmitter();
    }
    FilterSelectboxComponent.prototype.filterChanged = function (event) {
        // event.preventDefault();
        this.changed.emit(Array.isArray(event) ? '' : event.id); //Raise changed event
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], FilterSelectboxComponent.prototype, "items", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], FilterSelectboxComponent.prototype, "label", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', core_1.EventEmitter)
    ], FilterSelectboxComponent.prototype, "changed", void 0);
    FilterSelectboxComponent = __decorate([
        core_1.Component({
            selector: 'filter-selectbox',
            template: "\n    <form>\n          <b>{{label}}</b>:\n          <ng-select [allowClear]=\"true\"\n              [items]=\"items\"\n              [disabled]=\"disabled\"\n              placeholder=\"Not selected\"\n              (data)=\"filterChanged($event)\"\n              >\n          </ng-select>\n          <!--               (data)=\"refreshValue($event)\"\n              (selected)=\"selected($event)\"\n              (removed)=\"removed($event)\"\n              (typed)=\"typed($event)\"\n          -->\n          <!--input type=\"text\" name=\"filter\"\n                [(ngModel)]=\"model.filter\" \n                (keyup)=\"filterChanged($event)\"  /-->\n    </form>\n  ",
            directives: [common_1.FORM_DIRECTIVES, ng2_select_1.SELECT_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [])
    ], FilterSelectboxComponent);
    return FilterSelectboxComponent;
}());
exports.FilterSelectboxComponent = FilterSelectboxComponent;
//# sourceMappingURL=filterSelectbox.component.js.map