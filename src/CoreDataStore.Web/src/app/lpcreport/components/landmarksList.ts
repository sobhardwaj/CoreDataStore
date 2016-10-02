import { Component, Input, OnInit, AfterViewChecked, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'landmarks-list',
  templateUrl: 'app/details/components/landmarksList.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LandmarksListComponent {
  @Input() landmarks: any = null;

  constructor() {}

}
