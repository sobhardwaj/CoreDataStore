import { Component } from "@angular/core";
import { Input, OnInit } from "@angular/core";
import { Observable } from 'rxjs/Rx';

import { AppSettings } from '../../appsettings';
import { DiagnosticsService } from '../services/diagnostics';

@Component({
  selector: 'diagnostics',
  templateUrl: './app/diagnostics/components/diagnostics.html'
})

export class DiagnosticsComponent implements OnInit {

  ApiEndpoint: string = AppSettings.ApiEndpoint;
  @Input() diagnostics: any[] = [];

  constructor(private diagnosticsService: DiagnosticsService) {}

  ngOnInit() {
    Observable.interval(1000).subscribe(() => { this.getDiagnostics(); });
  }

  getDiagnostics() {
    this.diagnosticsService.getDiagnostics().subscribe(
      data => { this.diagnostics = data; },
      err => console.error(err),
      () => console.log('done loading diagnostics')
    );
  }
}
