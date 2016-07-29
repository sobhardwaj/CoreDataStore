import { Component } from "@angular/core";
import { OnInit } from "@angular/core";


import { DiagnosticsService } from '../services/diagnostics';

@Component({
  selector: 'diagnostics',
  templateUrl: './app/diagnostics/components/diagnostics.html'
})

export class DiagnosticsComponent implements OnInit {
  public diagnostics;

  constructor(private diagnosticsService: DiagnosticsService) {}
  ngOnInit() {
    this.getDiagnostics();
  }


  getDiagnostics() {
    this.diagnosticsService.getDiagnostics().subscribe(
      data => { this.diagnostics = data; },
      err => console.error(err),
      () => console.log('done loading diagnostics')
    );
  }
}