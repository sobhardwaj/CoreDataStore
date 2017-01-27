import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'filter-selectbox',
  template: `
    <form>
          <b>{{label}}</b>:
          <ng-select [allowClear]="true"
              [items]="items"
              [disabled]="disabled"
              [active]="selected"
              (data)="filterChanged($event)"
              placeholder="Not selected"
              >
          </ng-select>
    </form>
  `,
  // directives: [FORM_DIRECTIVES, SELECT_DIRECTIVES]
})

export class FilterSelectboxComponent implements OnInit {
  // model: { filter: string } = { filter: null };
  selected: any = [];
  constructor() {}

  ngOnInit() {
    if (this.active && this.active !== '') {
      this.selected.push({ id: this.active, text: this.active });
    }
  }

  @Input() items: Array < string > = [];
  @Input() label: string;
  @Input() active: string;

  @Output()
  changed: EventEmitter < string > = new EventEmitter < string > ();

  filterChanged(event: any) {
    // console.log(event);
    // event.preventDefault();
    this.changed.emit(Array.isArray(event) ? '' : event.id); //Raise changed event
  }
}
