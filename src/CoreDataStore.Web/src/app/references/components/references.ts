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
  limit: number = 20;
  perPage: any[] = [10, 20, 50, 100];
  totalItems: number = 100;
  fromItem: number = 1;
  toItem: number = 20;
  boroughs: string[] = [];
  objectTypes: string[] = [];
  // properties: IProperty[] = [];
  properties: any[] = []; // References;
  filteredReference: any[] = [];

  // displayMode: DisplayModeEnum;
  // displayModeEnum = DisplayModeEnum;

  constructor(private referenceService: ReferencesService) {}

  ngOnInit() {
    this.title = 'Reference';
    this.getObjectTypes();
    this.getBoroughs();
    this.getReferences(this.page, this.limit, this.borough, this.objectType);
  }

  getReferences(page, limit, borough, objectType) {
    this.referenceService.getReferences(page, limit, borough, objectType).subscribe(
      data => { this.properties = this.filteredReference = data; },
      () => console.log('done loading References')
    );

    let total = 1622; // will fix later 
    // subscribe((res) => {
    //   let headers = res.headers._headersMap;
    //   let total = headers.get('X-InlineCount');
    //   console.log(res);
    // });
    this.objectType = objectType;
    this.borough = borough;
    this.page = page;
    this.totalItems = total;
    this.fromItem = ((page - 1) * limit) + 1;
    this.toItem = (total < (page * limit)) ? total : (page * limit);
  }

  getObjectTypes() {
    this.referenceService.getObjectTypes().subscribe(
      data => { this.objectTypes = data; },
      err => console.error(err),
      () => console.log('done loading objectTypes')
    );
  }

  getBoroughs() {
    this.referenceService.getBoroughs().subscribe(
      data => { this.boroughs = data; },
      err => console.error(err),
      () => console.log('done loading boroughs')
    );
  }

  /*changeDisplayMode(mode: DisplayModeEnum) {
      this.displayMode = mode;
  }*/

  boroughChanged(data: string) {
    // console.log(data);
    this.borough = data;
    this.getReferences(this.page, this.limit, this.borough, this.objectType);
  }

  objectTypeChanged(data: string) {
    // console.log(data);
    this.objectType = data;
    this.getReferences(this.page, this.limit, this.borough, this.objectType);
  }

  pageChanged(event: any) {
    // console.log(event);
    // console.log('Page changed to: ' + event.page);
    // console.log('Number items per page: ' + event.itemsPerPage);  }
    this.page = event.page;
    this.getReferences(event.page, this.limit, this.borough, this.objectType);
  }

  perPageChanged(limit: any) {
    this.page = 1;
    this.limit = limit;
    this.getReferences(1, limit, this.borough, this.objectType);
  }
}

/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/
