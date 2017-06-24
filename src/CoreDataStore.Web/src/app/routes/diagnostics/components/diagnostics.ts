import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs/Rx';

import { AppSettings } from '../../appsettings';
import { DiagnosticsService } from '../services/diagnostics';

@Component({
  selector: 'diagnostics',
  providers: [DiagnosticsService],
  templateUrl: 'app/routes/diagnostics/components/diagnostics.html'
})

export class DiagnosticsComponent implements OnInit {
  private timer;
  build: string = AppSettings.build;
  ApiEndpoint: string = AppSettings.ApiEndpoint;
  ApiAttraction: string = AppSettings.ApiAttraction;
  ApiMaps: string = AppSettings.ApiMaps;
  ApiReports: string = AppSettings.ApiReports;
  ng2ENV: string = AppSettings.ng2ENV;
  browserEnabled: boolean = false;
  lat: number = 0;
  lng: number = 0;
  userRange: boolean = false;
  userLocation: any = {};
  @Input() diagnostics: any[] = [];

  constructor(private diagnosticsService: DiagnosticsService) {}

  getDiagnostics() {
    this.getLocation();
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

  getLocation() {
    if(navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((pos) => this.showPosition(pos));
    } else {
      this.browserEnabled = false;
    }
  }

  showPosition(position) {
    this.browserEnabled = true;
    this.lat = position.coords.latitude;
    this.lng = position.coords.longitude;
    this.diagnosticsService.getUserRange(this.lat, this.lng).subscribe(
      data => { this.userRange = data; },
      err => console.error(err),
      () => console.log('done loading diagnostics')
    );
    this.diagnosticsService.getUserLocation(this.lat, this.lng).subscribe(
      data => { this.userLocation = data; },
      err => console.error(err),
      () => console.log('done loading diagnostics')
    );
  }
}
