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
  public gridOptions: any;
  public landmarkProperties: any = [];
  public mapMarkers: any = [];
  public sub: any = null;
  public columns: Array < any > = [
    { headerName: 'Id', field: 'id', width: 50 },
    { headerName: 'Street', field: 'street', width: 200,sort: 'asc' },
    { headerName: 'Address', field: 'designatedAddress', width: 180 },
    { headerName: 'Block', field: 'block', width: 100 },
    { headerName: 'Lot', field: 'lot', width: 80 },
    { headerName: 'Building', field: 'isBuilding', width: 80 },
    { headerName: 'BLL', field: 'bbl', width: 120 },
    { headerName: 'BIN', field: 'binNumber', width: 120 },
    { headerName: 'PLUTO Address', field: 'plutoAddress', width: 180 },
    { headerName: 'LandMark', field: 'name', width: 200 },
    { headerName: 'LP Number', field: 'lpNumber', width: 150 },
    { headerName: 'Type', field: 'objectType', width: 125 },
    { headerName: 'Borough', field: 'boroughId', width: 75 }
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
                this.setWidthAndHeight('100%', '100%');
              } else {
                this.setWidthAndHeight('100%', '70px');
              }
              this.gridOptions.api.setRowData(this.landmarkProperties);
            },
            err => console.log(err)
          );
          this.plutoService.getMapMarkers(this.details.lpNumber).subscribe(
            data => {
              this.mapMarkers = data;
            }
          );
        },
        err => console.log(err)
      );
    });

    // ag-grid
    this.gridOptions = < GridOptions > {
      columnDefs: this.columns,
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
  }

  ngOnInit() {
    $(window).scrollTop(0, 0);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  public changePage(page: any) {}

  setWidthAndHeight(width: string = '100%', height: string = '100%') {
    var grid = this.elem.nativeElement.querySelector('#ag-grid');
    grid.style.width = width;
    grid.style.height = height;
    this.gridOptions.api.doLayout();
  }
}
