import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { CanActivate, CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Rx';


import { AppSettings } from '../../appsettings';
import { DiagnosticsService } from '../services/diagnostics';

@Component({
  selector: 'diagnostics',
  providers: [DiagnosticsService],
  templateUrl: './app/diagnostics/components/diagnostics.html'
})

export class MapsComponent implements OnInit {
  private timer;
  build: string = AppSettings.build;
  ApiEndpoint: string = AppSettings.ApiEndpoint;
  ApiAttraction: string = AppSettings.ApiAttraction;
  ng2ENV: string = AppSettings.ng2ENV;
  @Input() diagnostics: any[] = [];

  constructor(private diagnosticsService: DiagnosticsService) {}

  getDiagnostics() {
    this.diagnosticsService.getDiagnostics().subscribe(
      data => { this.diagnostics = data; },
      err => console.error(err),
      () => console.log('done loading diagnostics')
    );
  }
  ngOnInit() {
    this.timer = Observable.interval(1000).subscribe(() => { this.getDiagnostics(); });
  }

  ngOnDestroy() {
    this.timer.unsubscribe();
  }
}
