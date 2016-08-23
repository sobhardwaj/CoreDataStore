import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { FORM_DIRECTIVES, FormBuilder, Control, ControlGroup, Validators } from '@angular/common';

import { DetailsService } from '../services/details';
// import { SortByDirective } from '../directives/sortby.directive';
import { CapitalizePipe } from '../../pipes/capitalize';
import { TrimPipe } from '../../pipes/trim';

import { Sorter } from '../../utils/sorter';
import { TrackByService } from '../../services/trackby';

import { IProperty } from '../../interfaces';

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
  style: Control;
  dateDesignated: Control;
  street: Control;
  borough: Control;
  submitAttempt: boolean = false;
  formInit: boolean = false;
  formCanBeSubmitted: boolean = false;

  constructor(private sorter: Sorter, public trackby: TrackByService, private builder: FormBuilder,
      private detailsService: DetailsService) {
    this.designationReport = new Control('', Validators.required);
    this.objectType = new Control('', Validators.required);
    this.architect = new Control('', Validators.required);
    this.style = new Control('', Validators.required);
    this.dateDesignated = new Control('', Validators.required);
    this.street = new Control('', Validators.required);
    this.borough = new Control('', Validators.required);

    this.propertyDetailsForm = this.builder.group({
      designationReport: this.designationReport,
      objectType: this.objectType,
      architect: this.architect,
      style: this.style,
      dateDesignated: this.dateDesignated,
      street: this.street,
      borough: this.borough
    });
  }

  getSubmitStatus(cg) {
    // let dirtyValues = {};  // initialize empty object
    let hasSomethingtoSubmit = false;
    let hasErrors = false;
    Object.keys(cg.controls).forEach((c) => {
      let currentControl = cg.find(c);
      if (currentControl.dirty) {
        hasSomethingtoSubmit = true;
      }
      if (!currentControl.valid) {
        hasErrors = true;
      }
    });
    return hasSomethingtoSubmit && !hasErrors;
  }

  getDateFormatted(date) {
    var mm = date.getMonth() + 1; // getMonth() is zero-based
    var dd = date.getDate();
    return [(mm.length === 2 && '0') + mm, (dd.length === 2 && '0') + dd, date.getFullYear()].join('/'); // padding
  };

  ngAfterViewChecked() {
    if (!this.formInit && this.details) {
      this.formInit = true;
      (<Control>this.propertyDetailsForm.controls['designationReport']).updateValue(this.details.name);
      (<Control>this.propertyDetailsForm.controls['objectType']).updateValue(this.details.objectType);
      (<Control>this.propertyDetailsForm.controls['architect']).updateValue(this.details.architect);
      (<Control>this.propertyDetailsForm.controls['style']).updateValue(this.details.style);
      (<Control>this.propertyDetailsForm.controls['dateDesignated']).updateValue(
        this.getDateFormatted(new Date(this.details.dateDesignated))
      ); //'MM/dd/yyyy'
      (<Control>this.propertyDetailsForm.controls['street']).updateValue(this.details.street);
      (<Control>this.propertyDetailsForm.controls['borough']).updateValue(this.details.borough);
    }
    this.formCanBeSubmitted = this.getSubmitStatus(this.propertyDetailsForm);
    // console.log(this.details);
  }

  saveProperty() {
    let values = Object.assign({}, this.propertyDetailsForm.value);
    delete values.designationReport;
    let details:IProperty = values;
    details.id = this.details.id;
    details.lpcId = this.details.lpcId;
    details.lpNumber = this.details.lpNumber;
    details.photoStatus = this.details.photoStatus;
    details.photoURL = this.details.photoURL;
    details.name = this.propertyDetailsForm.value.designationReport;
    // delete details.designationReport;
    console.log(details);

    // Submit http request
    this.detailsService.updateProperty(details)
      .subscribe((result: boolean) => {
        console.log(result);
      });
  }

  /*sort(prop: string) {
      this.sorter.sort(this.properties, prop);
  }*/

}
