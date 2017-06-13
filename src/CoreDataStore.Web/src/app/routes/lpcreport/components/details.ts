declare var $: any;
import { Component, ElementRef, ViewContainerRef, ViewEncapsulation, OnInit, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { GridOptions } from 'ag-grid';


import { DetailFormComponent } from './detailForm';
import { LPCReportService } from '../services/lpcreport';
import { PlutoService } from '../services/pluto';
import { ReferencesService } from '../../references/services/references';

@Component({
  selector: 'properties-details',
  templateUrl: 'app/routes/lpcreport/components/details.html',
  providers: [LPCReportService, ReferencesService, PlutoService],
  encapsulation: ViewEncapsulation.None
})

export class DetailsComponent implements OnInit, OnDestroy {
  public title: string;
  public details: any;
  public gridOptionsPluto: any;
  public gridOptionsLandmarks: any;
  public landmarkProperties: any = [];
  public mapMarkers: any = [];
  public sub: any = null;
  public columnsLandmarks: Array < any > = [
    { headerName: 'Id', field: 'id', width: 50 },
    { headerName: 'Street', field: 'street', width: 200, editable: true, sort: 'asc' },
    { headerName: 'Address', field: 'designatedAddress', editable: true, width: 180 },
    { headerName: 'Block', field: 'block', editable: true, width: 100 },
    { headerName: 'Lot', field: 'lot', editable: true, width: 80 },
    { headerName: 'Building', field: 'isBuilding', editable: true, width: 80 },
    { headerName: 'BLL', field: 'bbl', editable: true, width: 120 },
    { headerName: 'BIN', field: 'binNumber', editable: true, width: 120 },
    { headerName: 'PLUTO Address', field: 'plutoAddress', editable: true, width: 180 },
    { headerName: 'LandMark', field: 'name', editable: true, width: 200 },
    { headerName: 'LP Number', field: 'lpNumber', editable: true, width: 150 },
    { headerName: 'Type', field: 'objectType', editable: true, width: 125 },
    { headerName: 'Borough', field: 'boroughId', editable: true, width: 75 }
  ];

  public columnsPluto: Array < any > = [
    { headerName: 'Id', field: 'id', width: 50 },
    { headerName: 'Address', field: 'address', editable: true, width: 180 },
    { headerName: 'Borough', field: 'borough', width: 200, editable: true },
    { headerName: 'Block', field: 'block', editable: true, width: 50 },
    { headerName: 'HistDist', field: 'histDist', editable: true, width: 120 },
    { headerName: 'Latitude', field: 'latitude', editable: true, width: 80 },
    { headerName: 'Longitude', field: 'longitude', editable: true, width: 80 },
    { headerName: 'Lot', field: 'lot', editable: true, width: 50 },
    { headerName: 'lotArea', field: 'lotArea', editable: true, width: 80 },
    { headerName: 'numBldgs', field: 'numBldgs', editable: true, width: 80 },
    { headerName: 'Owner Name', field: 'ownerName', editable: true, width: 200 },
    { headerName: 'xCoord', field: 'xCoord', editable: true, width: 50 },
    { headerName: 'yCoord', field: 'yCoord', editable: true, width: 50 },
    { headerName: 'year', field: 'yearBuilt', editable: true, width: 50 }
  ];

  /*@Inject(ActivatedRoute) */
  /*overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal*/
  constructor(
    private lpcReportService: LPCReportService,
    private plutoService: PlutoService,
    private elem: ElementRef,
    private route: ActivatedRoute) {
    // overlay.defaultViewContainer = vcRef;
    this.sub = this.route.params.subscribe(params => {
      let id = +params['id'];
      // console.log(id);
      this.lpcReportService.getLPCReport(id).subscribe(
        data => {
          this.details = data;
          this.title = data.name;
          this.lpcReportService.getLandmarkProperties(this.details.lpNumber).subscribe(
            data => {
              this.landmarkProperties = data || [];
              if (this.landmarkProperties.length > 1) {
                this.setWidthAndHeight('#ag-gridLandmarks', '100%', '100%');
              } else {
                this.setWidthAndHeight('#ag-gridLandmarks', '100%', '70px');
              }
              this.gridOptionsLandmarks.api.setRowData(this.landmarkProperties);
            },
            err => console.log(err)
          );
          this.plutoService.getMapMarkers(this.details.lpNumber).subscribe(
            data => {
              this.mapMarkers = data;
              if (this.mapMarkers.length > 1) {
                this.setWidthAndHeight('#ag-gridPluto', '100%', '100%');
              } else {
                this.setWidthAndHeight('#ag-gridPluto', '100%', '70px');
              }
              this.gridOptionsPluto.api.setRowData(this.mapMarkers);
            }
          );
        },
        err => console.log(err)
      );
    });

    // ag-grid gridOptionsLandmarks
    this.gridOptionsLandmarks = < GridOptions > {
      columnDefs: this.columnsLandmarks,
      rowData: null,
      // pagination: true,
      // paginationAutoPageSize: true,
      // paginationPageSize: 100,
      // paginationStartPage: 1,
      enableColResize: true,
      // enableSorting: true,
      // enableFilter: true,
      gridReady: (params) => {
        //   params.api.setWidthAndHeight('100%','100%');
        //   params.api.sizeColumnsToFit();
        //   this.$win.on(this.resizeEvent, () => {
        //     setTimeout(() => { params.api.sizeColumnsToFit(); });
        //   });
      }
    };

    // ag-grid gridOptionsLandmarks
    this.gridOptionsPluto = < GridOptions > {
      columnDefs: this.columnsPluto,
      rowData: null,
      // pagination: true,
      // paginationAutoPageSize: true,
      // paginationPageSize: 100,
      // paginationStartPage: 1,
      enableColResize: true,
      // enableSorting: true,
      // enableFilter: true,
      // gridReady: (params) => {
      //   params.api.setWidthAndHeight('100%','100%');
      //   params.api.sizeColumnsToFit();
      //   this.$win.on(this.resizeEvent, () => {
      //     setTimeout(() => { params.api.sizeColumnsToFit(); });
      //   });
      // }
    };
  }

  ngOnInit() {
    $(window).scrollTop(0, 0);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  public changePage(page: any) {}

  setWidthAndHeight(divId: string = '#ag-gridLandmarks', width: string = '100%', height: string = '100%') {
    var grid = this.elem.nativeElement.querySelector(divId);
    grid.style.width = width;
    grid.style.height = height;
    this.gridOptionsLandmarks.api.doLayout();
  }
}
