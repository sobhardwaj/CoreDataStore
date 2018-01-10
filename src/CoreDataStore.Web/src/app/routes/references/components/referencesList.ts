import { Component, Input, ChangeDetectionStrategy } from '@angular/core';
import { Router } from '@angular/router';

declare var $: any;

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
  @Input() showLoading = false;
  private mobileFlag:boolean = false;

  constructor(private router: Router) {
    if(window.innerWidth < 440) {
      this.mobileFlag = true;
    }

    if (localStorage.getItem('scrollTop')) {
      setTimeout(() => {
        $('body').scrollTop(localStorage.getItem('scrollTop'));
      }, 500);
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

  goDetails(id, index) {
    let top = $('.property_wrapper:nth-of-type(' + (index + 1) + ')').position().top;
    localStorage.setItem('scrollTop', top);
    this.router.navigate(['/details/' + id]);
  }
}
