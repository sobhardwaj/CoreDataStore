import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs/Rx';

import { AppSettings } from '../../../appsettings';
import { DiagnosticsService } from '../services/diagnostics';

@Component({
  selector: 'diagnostics',
  providers: [DiagnosticsService],
  templateUrl: 'app/routes/diagnostics/components/diagnostics.html'
})

export class DiagnosticsComponent implements OnInit {
  private timer;
  build: string = AppSettings.build;
  buildId: string = AppSettings.buildId;
  ApiEndpoint: string = AppSettings.ApiEndpoint;
  ApiAttraction: string = AppSettings.ApiAttraction;
  ApiMaps: string = AppSettings.ApiMaps;
  ApiReports: string = AppSettings.ApiReports;
  ApiLocation: string = AppSettings.ApiLocation;
  ng2ENV: string = AppSettings.ng2ENV;
  browserEnabled: boolean = false;
  lat: number = 0;
  lng: number = 0;
  userRange: boolean = false;
  userLocation: any = {};
  heading: any = [];
  localHeading: string = '';
  @Input() diagnostics: any[] = [];

  constructor(private diagnosticsService: DiagnosticsService) {
    this.getHeading();
    localStorage.setItem('heading', 'North');
  }

  getDiagnostics() {
    this.getLocation();
    this.diagnosticsService.getDiagnostics().subscribe(
      data => { this.diagnostics = data; },
      // err => console.error(err),
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

  getHeading() {
    this.diagnosticsService.getHeading().subscribe(data => {
      this.heading = data;
    });
  }

  setLocalHeading() {
    localStorage.setItem('heading', this.localHeading);
  }

  showPosition(position) {
    this.browserEnabled = true;
    this.lat = position.coords.latitude;
    this.lng = position.coords.longitude;
    let accuracy = position.coords.accuracy;
    let altitude = position.coords.altitude ? position.coords.altitude : 0;
    let altitudeAccuracy = position.coords.altitudeAccuracy ? position.coords.altitudeAccuracy : 0;
    let heading = position.coords.heading ? position.coords.heading : 0;
    let speed = position.coords.speed ? position.coords.speed : 0;
    let coords = {
      latitude: this.lat,
      longitude: this.lng,
      accuracy: accuracy,
      altitude: altitude,
      altitudeAccuracy: altitudeAccuracy,
      heading: heading,
      speed: speed
    };
    
    this.diagnosticsService.getUserRange(coords).subscribe(
      data => {
        this.userRange = data;
      },
      // err => console.error(err),
    );
    this.diagnosticsService.getUserLocation(coords).subscribe(
      data => {
        this.userLocation = data;
        this.heading.map(head => {
          if(head.value == data.coords.heading) {
            this.userLocation.coords.heading = head.description;
          }
        });
      },
      // err => console.error(err),
    );
  }
}
