import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
declare var $: any;

import { SessionService } from '../../../shared/services/session';

import { ReferencesService } from '../services/references';
import { LPCReportService } from '../../lpcreport/services/lpcreport';

import { ReferencesListComponent } from './referencesList';
import { FilterSelectboxComponent } from './filterSelectbox';

@Component({
  selector: 'properties',
  templateUrl: 'app/routes/references/components/references.html',
  providers: [ReferencesService, LPCReportService, SessionService]
})

export class ReferencesComponent implements OnInit {
  title: string;
  borough: string;
  objectType: string;
  neighborhood: string;
  ignorePageChangedEvent: boolean = false;
  page: number = 1;
  limit: number = 20;
  perPage: any[] = [10, 20, 50, 100];
  totalItems: number = 100;
  fromItem: number = 1;
  toItem: number = 20;
  boroughs: string[] = [];
  objectTypes: string[] = [];
  neighborhoods: string[] = [];
  tempNeighbors: any[] = [];
  properties: any[] = []; // LPCReports list;
  filteredReference: any[] = [];
  scrollPosition: number = 0;
  isMobile: boolean = false;
  disableNeighbor: boolean = true;

  // displayMode: DisplayModeEnum;
  // displayModeEnum = DisplayModeEnum;

  constructor(
    private session: SessionService,
    private referenceService: ReferencesService,
    private lpcReportService: LPCReportService,
    private changRef: ChangeDetectorRef) {
    let page = this.session.get('page');
    this.page = (parseInt(page, 10) > 0) ? page : 1;
  }

  ngOnInit() {
    this.title = 'LPC Reports';
    this.getObjectTypes();
    this.getBoroughs();
    this.getNeighborhoods();

    if(window.innerWidth < 768) {
      this.isMobile = true;
    } else {
      this.isMobile = false;
    }

    let objectType = this.session.get('objectType');
    this.objectType = (objectType) ? objectType : '';

    let borough = this.session.get('borough');
    this.borough = (borough) ? borough : '';

    let neighborhood = this.session.get('neighborhood');
    this.neighborhood = (neighborhood) ? neighborhood : '';

    this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
  }

  getLPCReports(page, limit, borough, objectType, neighborhood) {
    this.lpcReportService.getLPCReports(page, limit, borough, objectType, neighborhood).subscribe(
      data => {
        this.properties = this.filteredReference = data.reports;
        this.totalItems = data.total;
        if(!this.isMobile)
          this.scrollTop();

        this.objectType = objectType;
        this.borough = borough;
        this.neighborhood = neighborhood;
        this.page = page;
        this.fromItem = ((page - 1) * limit) + 1;
        this.toItem = (this.totalItems < (page * limit)) ? this.totalItems : (page * limit);
      },
      () => console.log('done loading getLPCReports')
    );
  }

  getObjectTypes() {
    this.referenceService.getObjectTypes().subscribe(
      data => { this.objectTypes = data; },
      err => console.error(err)
    );
  }

  getBoroughs() {
    this.referenceService.getBoroughs().subscribe(
      data => { this.boroughs = data; console.log(data)},
      err => console.error(err)
    );
  }

  getNeighborhoods() {
    this.referenceService.getNeighborhoods().subscribe(
      data => { 
        this.tempNeighbors = data;
        this.tempNeighbors.map(temp => {
          this.neighborhoods.push(temp.name);
        });
        console.log(this.neighborhoods);
      },
      err => console.error(err)
    );
  }

  /*changeDisplayMode(mode: DisplayModeEnum) {
      this.displayMode = mode;
  }*/

  boroughChanged(data: string) {
    // console.log(data);
    this.borough = data;
    this.neighborhoods = [];
    this.tempNeighbors.map(temp => {
      if(temp.location == this.borough) {
        this.neighborhoods.push(temp.name);
        this.neighborhood = "";
      }
    });
    this.disableNeighbor = false;
    if(data == "") {
      this.neighborhoods = [];
      this.neighborhood = "";
      this.disableNeighbor = true;
    }
    this.changRef.detectChanges();

    this.session.set('borough', data);
    this.page = 1;
    this.session.set('page', this.page);
    this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
  }

  objectTypeChanged(data: string) {
    // console.log(data);
    this.objectType = data;
    this.session.set('objectType', data);
    this.page = 1;
    this.session.set('page', this.page);
    this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
  }

  neighborhoodChanged(data: string) {
    // console.log(data);
    this.neighborhood = data;
    this.session.set('neighborhood', data);
    this.page = 1;
    this.session.set('page', this.page);
    this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
  }  

  public pageChanged(event: any) {
    if (!this.ignorePageChangedEvent) {
      this.page = event.page;
      this.session.set('page', this.page);
      this.getLPCReports(event.page, this.limit, this.borough, this.objectType, this.neighborhood);
    }
    this.ignorePageChangedEvent = false;
  }

  public perPageChanged(limit: any) {
    limit = parseInt(limit, 10);
    this.ignorePageChangedEvent =  this.limit < limit; //Little workaround for paginator last page cornercase
    this.page = 1;
    this.limit = limit;
    this.session.set('page', this.page);
    this.getLPCReports(1, limit, this.borough, this.objectType, this.neighborhood);
  }

  private scrollTop() {
    $(window).scrollTop(0, 0);
  }

  private onResize(event) {
    if(window.innerWidth < 768) {
      this.isMobile = true;
    } else {
      this.isMobile = false;
    }
  }

  private onScroll(event) {
    if(this.isMobile == true && $(window).scrollTop() + $(window).height() == $(document).height()) {
      this.session.set('page', this.page);
      this.limit += 20;
      this.scrollPosition = $(document).height();
      this.getLPCReports(this.page, this.limit, this.borough, this.objectType, this.neighborhood);
    }
  }
}

/*
enum DisplayModeEnum {
  Card = 0,
  Grid = 1,
  Map = 2
}
*/
