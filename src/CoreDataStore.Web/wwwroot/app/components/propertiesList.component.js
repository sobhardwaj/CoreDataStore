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
var router_1 = require('@angular/router');
// import { SortByDirective } from '../directives/sortby.directive';
var capitalize_pipe_1 = require('../pipes/capitalize.pipe');
var trim_pipe_1 = require('../pipes/trim.pipe');
var sorter_1 = require('../utils/sorter');
var trackby_service_1 = require('../services/trackby.service');
var PropertiesListComponent = (function () {
    function PropertiesListComponent(sorter, trackby) {
        this.sorter = sorter;
        this.trackby = trackby;
        this.properties = [];
    }
    PropertiesListComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], PropertiesListComponent.prototype, "properties", void 0);
    PropertiesListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'properties-list',
            templateUrl: 'propertiesList.component.html',
            directives: [router_1.ROUTER_DIRECTIVES /*, SortByDirective*/],
            pipes: [capitalize_pipe_1.CapitalizePipe, trim_pipe_1.TrimPipe],
            //When using OnPush detectors, then the framework will check an OnPush 
            //component when any of its input properties changes, when it fires 
            //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        }), 
        __metadata('design:paramtypes', [sorter_1.Sorter, trackby_service_1.TrackByService])
    ], PropertiesListComponent);
    return PropertiesListComponent;
}());
exports.PropertiesListComponent = PropertiesListComponent;
//# sourceMappingURL=propertiesList.component.js.map