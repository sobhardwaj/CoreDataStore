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
var data_service_1 = require('../services/data.service');
// import { FilterTextboxComponent } from '../filterTextbox/filterTextbox.component';
// import { CustomersCardComponent } from './customersCard.component';
var propertiesList_component_1 = require('./propertiesList.component');
var PropertiesComponent = (function () {
    // displayMode: DisplayModeEnum;
    // displayModeEnum = DisplayModeEnum;
    function PropertiesComponent(dataService) {
        this.dataService = dataService;
        this.properties = [];
        this.filteredProperties = [];
    }
    PropertiesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.title = 'Properties';
        this.filterText = 'Filter Properties:';
        // this.displayMode = DisplayModeEnum.Card;
        this.dataService.getProperties()
            .subscribe(function (properties) {
            _this.properties = _this.filteredProperties = properties;
            console.log(properties);
        });
    };
    /*changeDisplayMode(mode: DisplayModeEnum) {
        this.displayMode = mode;
    }*/
    PropertiesComponent.prototype.filterChanged = function (data) {
        /*if (data && this.customers) {
            data = data.toUpperCase();
            let props = ['firstName', 'lastName', 'address', 'city', 'orderTotal'];
            let filtered = this.customers.filter(item => {
                let match = false;
                for (let prop of props) {
                    //console.log(item[prop] + ' ' + item[prop].toUpperCase().indexOf(data));
                    if (item[prop].toString().toUpperCase().indexOf(data) > -1) {
                      match = true;
                      break;
                    }
                };
                return match;
            });
            this.filteredCustomers = filtered;
        }
        else {
          this.filteredCustomers = this.customers;
        }*/
    };
    PropertiesComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'properties',
            templateUrl: 'properties.component.html',
            directives: [router_1.ROUTER_DIRECTIVES, propertiesList_component_1.PropertiesListComponent /*FilterTextboxComponent,
                             CustomersCardComponent, CustomersGridComponent*/
            ]
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