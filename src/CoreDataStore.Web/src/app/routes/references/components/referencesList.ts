import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'references-list',
  styles: [
    `.search-results {
      height: 20rem;
      overflow: scroll;
    }`
  ],
  templateUrl: 'app/routes/references/components/referencesList.html',
  //When using OnPush detectors, then the framework will check an OnPush 
  //component when any of its input properties changes, when it fires 
  //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReferencesListComponent {
  @Input() properties: Object;
  private mobileFlag:boolean = false;

  constructor() {
    if(window.innerWidth < 440) {
      this.mobileFlag = true;
    }
  }
  
  onResize(event) {
    if(window.innerWidth < 440) {
      this.mobileFlag = true;
    } else {
      this.mobileFlag = false;
    }
  }

  onScroll() {
    console.log("scroll");
  }
}
