import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';
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
export class DetailsListComponent implements OnInit, AfterViewChecked {
  @Input() details: any;

  public form: FormGroup;
  public name: AbstractControl;
  public objectType: AbstractControl;
  public architect: AbstractControl;
  public style: AbstractControl;
  public dateDesignated: AbstractControl;
  public street: AbstractControl;
  public borough: AbstractControl;

  public submitted: boolean = false;

  constructor(private builder: FormBuilder, private lpcReportService: LPCReportService) {

  };

  ngOnInit() {
    this.form = this.builder.group({
      'name': ['', Validators.compose([Validators.required])],
      'objectType': ['', Validators.compose([Validators.required])],
      'architect': ['', Validators.compose([Validators.required])],
      'style': ['', Validators.compose([Validators.required])],
      'dateDesignated': ['', Validators.compose([Validators.required])],
      'street': ['', Validators.compose([Validators.required])],
      'borough': ['', Validators.compose([Validators.required])]
    });

    this.name = this.form.controls['name'];
    this.objectType = this.form.controls['objectType'];
    this.architect = this.form.controls['architect'];
    this.style = this.form.controls['style'];
    this.dateDesignated = this.form.controls['dateDesignated'];
    this.street = this.form.controls['street'];
    this.borough = this.form.controls['borough'];
  };

  ngAfterViewChecked() {
    if (this.details) {
      this.form.patchValue(this.details, { onlySelf: true });
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
      let details: IProperty = values;
      console.log(values);

      // Submit http request
      // this.lpcReportService.putLPCReport(details.id, details)
      //   .subscribe((result: boolean) => {
      //     console.log(result);
      //   }, e => {
      //     console.log(e);
      //   });
    }
  }
};
