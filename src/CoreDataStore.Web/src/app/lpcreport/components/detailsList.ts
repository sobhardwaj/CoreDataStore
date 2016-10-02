import { Component, Input, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';
// import { ROUTER_DIRECTIVES } from '@angular/router';
// import { FORM_DIRECTIVES, FormBuilder, Control, ControlGroup, Validators } from '@angular/common';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';

import { LPCReportService } from '../services/lpcreport';

import { IProperty } from '../../interfaces';

@Component({
  // moduleId: module.id,
  selector: 'details-list',
  templateUrl: 'app/lpcreport/components/detailsList.html',
  //When using OnPush detectors, then the framework will check an OnPush 
  //component when any of its input properties changes, when it fires 
  //an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DetailsListComponent implements AfterViewChecked {
  @Input() details: any;

  public form: FormGroup;
  public designationReport: AbstractControl;
  public objectType: AbstractControl;
  public architect: AbstractControl;
  public style: AbstractControl;
  public dateDesignated: AbstractControl;
  public street: AbstractControl;
  public borough: AbstractControl;

  public submitted: boolean = false;

  constructor(private builder: FormBuilder, private lpcReportService: LPCReportService) {
    this.form = this.builder.group({
      'designationReport': ['', Validators.compose([Validators.required])],
      'objectType': ['', Validators.compose([Validators.required])],
      'architect': ['', Validators.compose([Validators.required])],
      'style': ['', Validators.compose([Validators.required])],
      'dateDesignated': ['', Validators.compose([Validators.required])],
      'street': ['', Validators.compose([Validators.required])],
      'borough': ['', Validators.compose([Validators.required])]
    });

    this.designationReport = this.form.controls['designationReport'];
    this.objectType = this.form.controls['objectType'];
    this.architect = this.form.controls['architect'];
    this.style = this.form.controls['style'];
    this.street = this.form.controls['street'];
    this.borough = this.form.controls['borough'];
    this.dateDesignated = this.form.controls['dateDesignated'];
  };

  ngAfterViewChecked() {
    if (this.details) {
      ( < AbstractControl > this.form.controls['designationReport']).setValue(this.details.name, { onlySelf: true });
      ( < AbstractControl > this.form.controls['objectType']).setValue(this.details.objectType, { onlySelf: true });
      ( < AbstractControl > this.form.controls['architect']).setValue(this.details.architect, { onlySelf: true });
      ( < AbstractControl > this.form.controls['style']).setValue(this.details.style, { onlySelf: true });
      ( < AbstractControl > this.form.controls['street']).setValue(this.details.street, { onlySelf: true });
      ( < AbstractControl > this.form.controls['borough']).setValue(this.details.borough, { onlySelf: true });
      ( < AbstractControl > this.form.controls['dateDesignated']).setValue(this.details.dateDesignated, { onlySelf: true });
    }
  };

  getDateFormatted(date) {
    var mm = date.getMonth() + 1; // getMonth() is zero-based
    var dd = date.getDate();
    return [(mm.length === 2 && '0') + mm, (dd.length === 2 && '0') + dd, date.getFullYear()].join('/'); // padding
  };

  public onSubmit(values: Object): void {
    this.submitted = true;
    if (this.form.valid) {
      let values = this.form.value;
      delete values.designationReport;
      let details: IProperty = values;
      details.id = this.details.id;
      details.lpcId = this.details.lpcId;
      details.lpNumber = this.details.lpNumber;
      details.photoStatus = this.details.photoStatus;
      details.photoURL = this.details.photoURL;
      details.name = this.form.value.designationReport;
      // console.log(details);

      // Submit http request
      this.lpcReportService.putLPCReport(details.id, details)
        .subscribe((result: boolean) => {
          console.log(result);
        }, e => {
          console.log(e);
        });
    }

    console.log(values);
  }
};
