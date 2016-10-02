import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'landmarks-list',
  templateUrl: 'app/lpcreport/components/landmarksList.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LandmarksListComponent {
  @Input() landmarks: any = null;

  constructor() {}

}
