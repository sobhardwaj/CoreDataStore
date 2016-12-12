import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'landmarks-list',
  templateUrl: 'app/routes/lpcreport/components/landmarksList.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LandmarksListComponent {
  @Input() landmarks: any = null;

  constructor() {}

}
