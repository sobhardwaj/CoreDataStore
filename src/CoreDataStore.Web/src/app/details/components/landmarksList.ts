import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { DetailsService } from '../services/details';
// import { SortByDirective } from '../directives/sortby.directive';
import { CapitalizePipe } from '../../pipes/capitalize';
import { TrimPipe } from '../../pipes/trim';

import { Sorter } from '../../utils/sorter';
import { TrackByService } from '../../services/trackby';

import { IProperty } from '../../interfaces';

@Component({
  selector: 'landmarks-list',
  templateUrl: 'app/details/components/landmarksList.html',
  directives: [ROUTER_DIRECTIVES, /*, SortByDirective*/ ],
  pipes: [CapitalizePipe, TrimPipe],
  //When using OnPush detectors, then the framework will check an OnPush 
  //component when any of its input properties changes, when it fires 
  //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LandmarksListComponent {
  @Input() landmarks: any = null;

  constructor(private sorter: Sorter, public trackby: TrackByService) {
  }

}
