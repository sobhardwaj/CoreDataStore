import { Component, ViewContainerRef, ViewEncapsulation, OnInit, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, ROUTER_DIRECTIVES } from '@angular/router';
//import { Observable } from 'rxjs/Observable';
import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';
// import { Overlay } from 'angular2-modal';
// import { Modal } from 'angular2-modal/plugins/bootstrap';

import { DetailsListComponent } from './detailsList';
import { LandmarksListComponent } from './landmarksList';
import { DetailsService } from '../services/details';
import { IProperty } from '../../interfaces';

@Component({
  selector: 'properties-details',
  templateUrl: 'app/details/components/details.html',
  directives: [
    PAGINATION_DIRECTIVES, ROUTER_DIRECTIVES,
    DetailsListComponent,
    LandmarksListComponent
  ],
})
export class DetailsComponent implements OnInit, OnDestroy {
  title: string;
  details: IProperty = null;
  landmarkProperties: any = null;
  sub: any = null;

  /*@Inject(ActivatedRoute) */
  constructor(private detailsService: DetailsService, private location: Location, private route: ActivatedRoute
    /*overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal*/) {
    // overlay.defaultViewContainer = vcRef;
  }

  ngOnInit() {
    this.title = 'Details';


    this.sub = this.route.params.subscribe(params => {
      let id = +params['id'];
      // console.log(id);
      this.detailsService.getDetails(id)
        .subscribe((details: IProperty) => {
          this.details = details;
          // console.log(details);
          this.detailsService.getLandmarkProperties(details.lpNumber)
            .subscribe((lp: any) => {
              // console.log(lp);
              this.landmarkProperties = lp;
            }, e => {
              console.log(e);

              /*this.modal.alert()
                .size('lg')
                .showClose(true)
                .title('A simple Alert style modal window')
                .body(`
                    <h4>Alert is a classic (title/body/footer) 1 button modal window that 
                    does not block.</h4>
                    <b>Configuration:</b>
                    <ul>
                        <li>Non blocking (click anywhere outside to dismiss)</li>
                        <li>Size large</li>
                        <li>Dismissed with default keyboard key (ESC)</li>
                        <li>Close wth button click</li>
                        <li>HTML content</li>
                    </ul>`)
                .open();*/

              alert('Error: ' + e);
            });

        }, e => {
          console.log(e);
          alert('Error: ' + e);
        });
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  goBack() {
    this.location.back();
  }
}
