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
    { headerName: 'Id', field: 'id', sort: 'asc', width: 80 },
    { headerName: 'BLL', field: 'bbl', width: 120 },
    { headerName: 'BIN_NUMBER', field: 'binNumber', width: 120 },
    { headerName: 'BoroughID', field: 'boroughId', width: 100 },
    { headerName: 'BLOCK', field: 'block', width: 100 },
    { headerName: 'LOT', field: 'lot', width: 80 },
    { headerName: 'LP_NUMBER', field: 'lpNumber', width: 150 },
    { headerName: 'LM_NAME', field: 'name', width: 180 },
    { headerName: 'PLUTO_ADDR', field: 'designatedAddress', width: 180 },
    { headerName: 'DESIG_ADDR', field: 'plutoAddress', width: 180 }
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
      enableSorting: true,
      enableFilter: true,
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
