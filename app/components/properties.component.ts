import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
//import { Observable } from 'rxjs/Observable';

import { DataService } from '../services/data.service';
// import { FilterTextboxComponent } from '../filterTextbox/filterTextbox.component';
// import { CustomersCardComponent } from './customersCard.component';
import { PropertiesListComponent } from './propertiesList.component'
import { IProperty } from '../interfaces';

@Component({ 
  moduleId: module.id,
  selector: 'properties', 
  templateUrl: 'properties.component.html',
  directives: [ROUTER_DIRECTIVES, PropertiesListComponent /*FilterTextboxComponent, 
               CustomersCardComponent, CustomersGridComponent*/]
})
export class PropertiesComponent implements OnInit {

  title: string;
  filterText: string;
  properties: IProperty[] = [];
  filteredProperties: IProperty[] = [];
  // displayMode: DisplayModeEnum;
  // displayModeEnum = DisplayModeEnum;

  constructor(private dataService: DataService) { }
  
  ngOnInit() {
    this.title = 'Properties';
    this.filterText = 'Filter Properties:';
    // this.displayMode = DisplayModeEnum.Card;

    this.dataService.getProperties()
      .subscribe((properties: IProperty[]) => {
        this.properties = this.filteredProperties = properties;
        console.log(properties);
      });
  }

  /*changeDisplayMode(mode: DisplayModeEnum) {
      this.displayMode = mode;
  }*/

  filterChanged(data: string) {
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
  }

}

/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/