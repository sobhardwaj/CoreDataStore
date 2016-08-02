import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FORM_DIRECTIVES } from '@angular/common';
import { SELECT_DIRECTIVES } from 'ng2-select';

@Component({
  selector: 'filter-selectbox',
  template: `
    <form>
          <b>{{label}}</b>:
          <ng-select [allowClear]="true"
              [items]="items"
              [disabled]="disabled"
              placeholder="Not selected"
              (data)="filterChanged($event)"
              >
          </ng-select>
          <!--               (data)="refreshValue($event)"
              (selected)="selected($event)"
              (removed)="removed($event)"
              (typed)="typed($event)"
          -->
          <!--input type="text" name="filter"
                [(ngModel)]="model.filter" 
                (keyup)="filterChanged($event)"  /-->
    </form>
  `,
  directives: [FORM_DIRECTIVES, SELECT_DIRECTIVES]
})
export class FilterSelectboxComponent {
  model: { filter: string } = { filter: null };

  @Input()
  public items: Array < string > = [];

  @Input()
  label: string;

  @Output()
  changed: EventEmitter < string > = new EventEmitter < string > ();

  filterChanged(event: any) {
    // event.preventDefault();
    this.changed.emit(Array.isArray(event) ? '' : event.id); //Raise changed event
  }
}
