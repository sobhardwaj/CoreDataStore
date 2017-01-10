import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'filter-selectbox',
  template: `
    <form>
          <b>{{label}}</b>:
          <ng-select [allowClear]="true"
              [items]="items"
              [disabled]="disabled"
              (data)="filterChanged($event)"
              placeholder="Not selected"
              >
          </ng-select>
    </form>
  `,
  // directives: [FORM_DIRECTIVES, SELECT_DIRECTIVES]
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
