import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

@Component({
    selector: 'references-list',
    templateUrl: 'app/references/components/referencesList.html',
    //When using OnPush detectors, then the framework will check an OnPush 
    //component when any of its input properties changes, when it fires 
    //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReferencesListComponent {

    @Input() properties: Object;

    /*sort(prop: string) {
        this.sorter.sort(this.properties, prop);
    }*/

}
