import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../../core/settings/settings.service';

@Component({
  selector: '[app-footer]',
  templateUrl: 'app/layout/footer/footer.component.html'
})
export class FooterComponent implements OnInit {

  constructor(public settings: SettingsService) {}

  ngOnInit() {

  }

}
