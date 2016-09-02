import { Component } from "@angular/core";
import { Input } from "@angular/core";
import { Observable } from 'rxjs/Rx';
import { OnActivate } from '@angular/router';

import { AppSettings } from '../../appsettings';
import { DiagnosticsService } from '../services/diagnostics';

@Component({
  selector: 'diagnostics',
  templateUrl: './app/diagnostics/components/diagnostics.html'
})

export class DiagnosticsComponent implements OnActivate {
  public timer;
  ApiEndpoint: string = AppSettings.ApiEndpoint;
  @Input() diagnostics: any[] = [];

  constructor(private diagnosticsService: DiagnosticsService) {}

  getDiagnostics() {
    this.diagnosticsService.getDiagnostics().subscribe(
      data => { this.diagnostics = data; },
      err => console.error(err),
      () => console.log('done loading diagnostics')
    );
  }

  routerOnActivate() {
    this.timer = Observable.interval(1000).subscribe(() => { this.getDiagnostics(); });
  };

  routerCanDeactivate() {
    this.timer.unsubscribe();
    return true;
  };
}
