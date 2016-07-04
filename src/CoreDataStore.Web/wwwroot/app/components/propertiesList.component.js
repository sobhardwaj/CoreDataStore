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
//import { Observable } from 'rxjs/Observable';
var ng2_bootstrap_1 = require('ng2-bootstrap/ng2-bootstrap');
var data_service_1 = require('../services/data.service');
var filterTextbox_component_1 = require('./filterTextbox.component');
var filterSelectbox_component_1 = require('./filterSelectbox.component');
// import { CustomersCardComponent } from './customersCard.component';
var propertiesList_component_1 = require('./propertiesList.component');
var PropertiesComponent = (function () {
    // displayMode: DisplayModeEnum;
    // displayModeEnum = DisplayModeEnum;
    function PropertiesComponent(dataService) {
        this.dataService = dataService;
        this.borough = '';
        this.objectType = '';
        this.page = 1;
        this.boroughs = [];
        this.objectTypes = [];
        this.properties = [];
        this.filteredProperties = [];
        this.totalItems = 100;
    }
    PropertiesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.title = 'Properties';
        // this.displayMode = DisplayModeEnum.Card;
        this.dataService.getProperties(this.borough, this.objectType, this.page)
            .subscribe(function (properties) {
            _this.properties = _this.filteredProperties = properties;
            // console.log(properties);
        });
        this.dataService.getBoroughs()
            .subscribe(function (boroughs) {
            _this.boroughs = boroughs;
            // console.log(boroughs);
        });
        this.dataService.getObjectTypes()
            .subscribe(function (objectTypes) {
            _this.objectTypes = objectTypes;
            // console.log(objectTypes);
        });
    };
    /*changeDisplayMode(mode: DisplayModeEnum) {
        this.displayMode = mode;
    }*/
    PropertiesComponent.prototype.boroughChanged = function (data) {
        var _this = this;
        // console.log(data);
        this.borough = data;
        this.dataService.getProperties(this.borough, this.objectType, this.page)
            .subscribe(function (properties) {
            _this.properties = _this.filteredProperties = properties;
            // console.log(properties);
        });
    };
    PropertiesComponent.prototype.objectTypeChanged = function (data) {
        var _this = this;
        // console.log(data);
        this.objectType = data;
        this.dataService.getProperties(this.borough, this.objectType, this.page)
            .subscribe(function (properties) {
            _this.properties = _this.filteredProperties = properties;
            // console.log(properties);
        });
    };
    PropertiesComponent.prototype.pageChanged = function (event) {
        var _this = this;
        // console.log(event);
        // console.log('Page changed to: ' + event.page);
        // console.log('Number items per page: ' + event.itemsPerPage);  }
        this.page = event.page;
        this.dataService.getProperties(this.borough, this.objectType, this.page)
            .subscribe(function (properties) {
            _this.properties = _this.filteredProperties = properties;
            // console.log(properties);
        });
    };
    PropertiesComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'properties',
            templateUrl: 'properties.component.html',
            directives: [ng2_bootstrap_1.PAGINATION_DIRECTIVES, router_1.ROUTER_DIRECTIVES, propertiesList_component_1.PropertiesListComponent, filterTextbox_component_1.FilterTextboxComponent, filterSelectbox_component_1.FilterSelectboxComponent
            ],
        }), 
        __metadata('design:paramtypes', [data_service_1.DataService])
    ], PropertiesComponent);
    return PropertiesComponent;
}());
exports.PropertiesComponent = PropertiesComponent;
/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/ 
//# sourceMappingURL=properties.component.js.map