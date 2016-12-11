import { Component, OnInit } from '@angular/core';
import { UserblockService } from './userblock.service';

@Component({
  selector: 'app-userblock',
  templateUrl: 'app/layout/sidebar/userblock/userblock.component.html'
})
export class UserblockComponent implements OnInit {
  user: any;
  constructor(private userblockService: UserblockService) {

    this.user = {
      picture: 'img/user/01.jpg'
    };
  }

  ngOnInit() {}

  userBlockIsVisible() {
    return this.userblockService.getVisibility();
  }

}
