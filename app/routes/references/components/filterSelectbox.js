System.register(['@angular/core'], function(exports_1, context_1) {
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
    var core_1;
    var FilterSelectboxComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            FilterSelectboxComponent = (function () {
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
                        template: "\n    <form>\n          <b>{{label}}</b>:\n          <ng-select [allowClear]=\"true\"\n              [items]=\"items\"\n              [disabled]=\"disabled\"\n              (data)=\"filterChanged($event)\"\n              placeholder=\"Not selected\"\n              >\n          </ng-select>\n    </form>\n  ",
                    }), 
                    __metadata('design:paramtypes', [])
                ], FilterSelectboxComponent);
                return FilterSelectboxComponent;
            }());
            exports_1("FilterSelectboxComponent", FilterSelectboxComponent);
        }
    }
});
