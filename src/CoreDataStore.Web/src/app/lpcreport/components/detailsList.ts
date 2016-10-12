import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';

import { LPCReportService } from '../services/lpcreport';
import { ReferencesService } from '../../references/services/references';


import { LPCReport } from '../models/lpcreport';

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

  public objectTypes: Object;
  public boroughs: Object;

  public form: FormGroup;
  public name: AbstractControl;
  public objectType: AbstractControl;
  public architect: AbstractControl;
  public style: AbstractControl;
  public dateDesignated: AbstractControl;
  public street: AbstractControl;
  public borough: AbstractControl;

  public submitted: boolean = false;
  public formInitted: boolean = false;

  constructor(
    private builder: FormBuilder,
    private location: Location,
    private referenceService: ReferencesService,
    private lpcReportService: LPCReportService) {
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

  getObjectTypes() {
    this.referenceService.getObjectTypes().subscribe(
      data => { this.objectTypes = data; },
      err => console.error(err)
    );
  }

  getBoroughs() {
    this.referenceService.getBoroughs().subscribe(
      data => { this.boroughs = data; },
      err => console.error(err)
    );
  }

  ngOnInit() {
    this.getObjectTypes();
    this.getBoroughs();
  };

  ngAfterViewChecked() {
    if (this.details && !this.formInitted) {
      this.form.patchValue(this.details, { onlySelf: true });
      this.formInitted = true;
    }
  };

  getDateFormatted(date) {
    var mm = date.getMonth() + 1; // getMonth() is zero-based
    var dd = date.getDate();
    return [(mm.length === 2 && '0') + mm, (dd.length === 2 && '0') + dd, date.getFullYear()].join('/'); // padding
  };

  public onSubmit(values: Object) {
    this.submitted = true;
    if (this.form.valid) {
      let details: LPCReport = values;
      details.id = this.details.id;
      // console.log(values);
      // Submit http request
      this.lpcReportService.putLPCReport(this.details.id, values)
        .subscribe(
          (res) => {
            console.log(res);
            this.location.back();
          },
          e => { console.log(e); }
        );
    }
  }
};
