import { Component, OnInit } from '@angular/core';

import { ReferencesService } from '../services/references';
import { LPCReportService } from '../../lpcreport/services/lpcreport';
// import { FilterTextboxComponent } from '../../components/filterTextbox';
// import { FilterSelectboxComponent } from '../../components/filterSelectbox';
// import { CustomersCardComponent } from './customersCard.component';
import { ReferencesListComponent } from './referencesList';

@Component({
  selector: 'properties',
  templateUrl: 'app/references/components/references.html',
  providers: [ReferencesService, LPCReportService]
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
  properties: any[] = []; // LPCReports list;
  filteredReference: any[] = [];

  // displayMode: DisplayModeEnum;
  // displayModeEnum = DisplayModeEnum;

  constructor(private referenceService: ReferencesService, private lpcReportService: LPCReportService) {}

  ngOnInit() {
    this.title = 'Reference';
    this.getObjectTypes();
    this.getBoroughs();
    this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
  }

  getLPCReports(page, limit, borough, objectType) {
    this.lpcReportService.getLPCReports(page, limit, borough, objectType).subscribe(
      data => { this.properties = this.filteredReference = data; },
      () => console.log('done loading getLPCReports')
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
    this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
  }

  objectTypeChanged(data: string) {
    // console.log(data);
    this.objectType = data;
    this.getLPCReports(this.page, this.limit, this.borough, this.objectType);
  }

  pageChanged(event: any) {
    // console.log(event);
    this.page = event.page;
    this.getLPCReports(event.page, this.limit, this.borough, this.objectType);
  }

  perPageChanged(limit: any) {
    this.page = 1;
    this.limit = limit;
    this.getLPCReports(1, limit, this.borough, this.objectType);
  }
}

/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/
