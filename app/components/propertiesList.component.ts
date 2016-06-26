import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

// import { SortByDirective } from '../directives/sortby.directive';
import { CapitalizePipe } from '../pipes/capitalize.pipe';
import { TrimPipe } from '../pipes/trim.pipe';
import { Sorter } from '../utils/sorter';
import { TrackByService } from '../services/trackby.service';

@Component({ 
  moduleId: module.id,
  selector: 'properties-list', 
  templateUrl: 'propertiesList.component.html',
  directives: [ROUTER_DIRECTIVES/*, SortByDirective*/],
  pipes: [CapitalizePipe, TrimPipe],
  //When using OnPush detectors, then the framework will check an OnPush 
  //component when any of its input properties changes, when it fires 
  //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
  changeDetection: ChangeDetectionStrategy.OnPush 
})
export class PropertiesListComponent implements OnInit {

  @Input() properties: any[] = [];

  constructor(private sorter: Sorter, public trackby: TrackByService) { }
   
  ngOnInit() {

  }

  /*sort(prop: string) {
      this.sorter.sort(this.properties, prop);
  }*/

}
