import { Component, ViewChild, OnInit } from '@angular/core';
import SettingsService from './services/setting';

const screenfull = require('screenfull');
const browser = require('jquery.browser');
declare var $: any;

@Component({
  selector: "app",
  templateUrl: "./app/app.html"
})
export class AppComponent implements OnInit {
  isNavSearchVisible: boolean;
  @ViewChild('fsbutton') fsbutton; // the fullscreen button

  constructor(private settings: SettingsService) {}

  ngOnInit() {
    this.isNavSearchVisible = false;
    if (browser.msie) { // Not supported under IE
      this.fsbutton.nativeElement.style.display = 'none';
    }
  }

  openNavSearch(event) {
    event.preventDefault();
    event.stopPropagation();
    this.setNavSearchVisible(true);
  }

  setNavSearchVisible(stat: boolean) {
    // console.log(stat);
    this.isNavSearchVisible = stat;
  }

  getNavSearchVisible() {
    return this.isNavSearchVisible;
  }

  toggleOffsidebar() {
    this.settings.layout.offsidebarOpen = !this.settings.layout.offsidebarOpen;
  }

  toggleCollapsedSideabar() {
    this.settings.layout.isCollapsed = !this.settings.layout.isCollapsed;
  }

  isCollapsedText() {
    return this.settings.layout.isCollapsedText;
  }

  toggleFullScreen(event) {

    if (screenfull.enabled) {
      screenfull.toggle();
    }
    // Switch icon indicator
    let el = $(this.fsbutton.nativeElement);
    if (screenfull.isFullscreen) {
      el.children('em').removeClass('fa-expand').addClass('fa-compress');
    } else {
      el.children('em').removeClass('fa-compress').addClass('fa-expand');
    }
  }
}
