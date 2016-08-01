import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
//import { Observable } from 'rxjs/Observable';
import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';

import { ReferencesService } from '../services/references';
import { FilterTextboxComponent } from '../../components/filterTextbox';
import { FilterSelectboxComponent } from '../../components/filterSelectbox';
// import { CustomersCardComponent } from './customersCard.component';
import { ReferencesListComponent } from './referencesList';
import { IProperty } from '../../interfaces';

@Component({
  // moduleId: module.id,
  selector: 'properties',
  templateUrl: 'app/references/components/references.html',
  directives: [
    PAGINATION_DIRECTIVES, ROUTER_DIRECTIVES,
     ReferencesListComponent, FilterTextboxComponent, FilterSelectboxComponent
    /* CustomersCardComponent, CustomersGridComponent*/
  ],
})
export class ReferencesComponent implements OnInit {
  title: string;
  borough: string = '';
  objectType: string = '';
  page: number = 1;
  boroughs: string[] = [];
  objectTypes: string[] = [];
  properties: IProperty[] = [];
  filteredReference: IProperty[] = [];
  totalItems: number = 100;
  // displayMode: DisplayModeEnum;
  // displayModeEnum = DisplayModeEnum;

  constructor(private referenceService: ReferencesService) {}

  ngOnInit() {
    this.title = 'Reference';
    // this.displayMode = DisplayModeEnum.Card;

    this.referenceService.getReference(this.borough, this.objectType, this.page)
      .subscribe((properties: IProperty[]) => {
        this.properties = this.filteredReference = properties;
        // console.log(properties);
      });

    this.referenceService.getBoroughs()
      .subscribe((boroughs: string[]) => {
        this.boroughs = boroughs;
        // console.log(boroughs);
      });

    this.referenceService.getObjectTypes()
      .subscribe((objectTypes: string[]) => {
        this.objectTypes = objectTypes;
        // console.log(objectTypes);
      });
  }

  /*changeDisplayMode(mode: DisplayModeEnum) {
      this.displayMode = mode;
  }*/

  boroughChanged(data: string) {
    // console.log(data);
    this.borough = data;
    this.referenceService.getReference(this.borough, this.objectType, this.page)
      .subscribe((properties: IProperty[]) => {
        this.properties = this.filteredReference = properties;
        // console.log(properties);
      });
  }

  objectTypeChanged(data: string) {
    // console.log(data);
    this.objectType = data;
    this.referenceService.getReference(this.borough, this.objectType, this.page)
      .subscribe((properties: IProperty[]) => {
        this.properties = this.filteredReference = properties;
        // console.log(properties);
      });
  }

  pageChanged(event: any) {
    // console.log(event);
    // console.log('Page changed to: ' + event.page);
    // console.log('Number items per page: ' + event.itemsPerPage);  }
    this.page = event.page;
    this.referenceService.getReference(this.borough, this.objectType, this.page)
      .subscribe((properties: IProperty[]) => {
        this.properties = this.filteredReference = properties;
        // console.log(properties);
      });
  }
}

/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/
