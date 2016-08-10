import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { FORM_DIRECTIVES, FormBuilder, Control, ControlGroup, Validators } from '@angular/common';

// import { SortByDirective } from '../directives/sortby.directive';
import { CapitalizePipe } from '../../pipes/capitalize';
import { TrimPipe } from '../../pipes/trim';

import { Sorter } from '../../utils/sorter';
import { TrackByService } from '../../services/trackby';

@Component({
  // moduleId: module.id,
  selector: 'details-list',
  templateUrl: 'app/details/components/detailsList.html',
  directives: [ROUTER_DIRECTIVES, FORM_DIRECTIVES /*, SortByDirective*/ ],
  pipes: [CapitalizePipe, TrimPipe],
  //When using OnPush detectors, then the framework will check an OnPush 
  //component when any of its input properties changes, when it fires 
  //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DetailsListComponent implements AfterViewChecked {
  @Input() details: any = null;

  propertyDetailsForm: ControlGroup;
  designationReport: Control;
  objectType: Control;
  architect: Control;
  submitAttempt: boolean = false;
  formInit: boolean = false;

  constructor(private sorter: Sorter, public trackby: TrackByService, private builder: FormBuilder) {
    this.designationReport = new Control('', Validators.required);
    this.objectType = new Control('', Validators.required);
    this.architect = new Control('', Validators.required);

    this.propertyDetailsForm = this.builder.group({
      designationReport: this.designationReport,
      objectType: this.objectType,
      architect: this.architect
    });
  }

  ngAfterViewChecked() {
    if (!this.formInit && this.details) {
      this.formInit = true;
      (<Control>this.propertyDetailsForm.controls['designationReport']).updateValue(this.details.name);
      (<Control>this.propertyDetailsForm.controls['objectType']).updateValue(this.details.objectType);
      (<Control>this.propertyDetailsForm.controls['architect']).updateValue(this.details.architect);
    }
    // console.log(this.details);
  }

  /*sort(prop: string) {
      this.sorter.sort(this.properties, prop);
  }*/

}
