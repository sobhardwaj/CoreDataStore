import { Component, OnInit, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, ROUTER_DIRECTIVES } from '@angular/router';
//import { Observable } from 'rxjs/Observable';
import { PAGINATION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';

import { DetailsListComponent } from './detailsList';
import { DetailsService } from '../services/details';
import { IProperty } from '../../interfaces';

@Component({
  selector: 'properties-details',
  templateUrl: 'app/details/components/details.html',
  directives: [
    PAGINATION_DIRECTIVES, ROUTER_DIRECTIVES,
    DetailsListComponent
  ],
})
export class DetailsComponent implements OnInit, OnDestroy {
  title: string;
  details: IProperty = null;
  sub: any = null;

/*@Inject(ActivatedRoute) */
  constructor(private detailsService: DetailsService, private location: Location, private route: ActivatedRoute) {}

  ngOnInit() {
    this.title = 'Details';

    this.sub = this.route.params.subscribe(params => {
      let id = +params['id'];
      // console.log(id);
      this.detailsService.getDetails(id)
        .subscribe((details: IProperty) => {
          this.details = details;
          // console.log(details);
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
