import { Component, ViewContainerRef, ViewEncapsulation, OnInit, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

// import { Overlay } from 'angular2-modal';
// import { Modal } from 'angular2-modal/plugins/bootstrap';

import { DetailsListComponent } from './detailsList';
import { LandmarksListComponent } from './landmarksList';
import { LPCReportService } from '../services/lpcreport';
import { ReferencesService } from '../../references/services/references';

@Component({
  selector: 'properties-details',
  templateUrl: 'app/routes/lpcreport/components/details.html',
  providers: [LPCReportService, ReferencesService]
})

export class DetailsComponent implements OnInit, OnDestroy {
  public title: string;
  public details: any;
  public latitude: any;
  public longitude: any;
  public landmarkProperties: any = null;
  public sub: any = null;

  /*@Inject(ActivatedRoute) */
  constructor(private lpcReportService: LPCReportService, private route: ActivatedRoute
    /*overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal*/
  ) {
    // overlay.defaultViewContainer = vcRef;
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      let id = +params['id'];
      // console.log(id);
      this.lpcReportService.getLPCReport(id).subscribe(
        data => {
          this.details = data;
          this.latitude = data.latitude;
          this.longitude = data.longitude;
          this.title = data.name;
          this.lpcReportService.getLandmarkProperties(this.details.lpNumber).subscribe(
            data => { this.landmarkProperties = data; },
            () => console.log('done loading getLandmarkProperties')
          );
        }
      );
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
