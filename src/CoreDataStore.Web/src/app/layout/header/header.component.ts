import { Component, OnInit, ViewChild } from '@angular/core';

import { SettingsService } from '../../core/settings/settings.service';

import * as screenfull from 'screenfull';
import * as browser from 'jquery.browser';
declare var $: any;

@Component({
  selector: 'app-header',
  templateUrl: 'app/layout/header/header.component.html'
})
export class HeaderComponent implements OnInit {
  isNavSearchVisible: boolean;
  isMobile: boolean = false;
  locationEnabled: boolean = false;
  @ViewChild('fsbutton') fsbutton; // the fullscreen button

  constructor(private settings: SettingsService) {}

  ngOnInit() {
    this.isNavSearchVisible = false;
    if (browser.msie) { // Not supported under IE
      this.fsbutton.nativeElement.style.display = 'none';
    }
    
    if(navigator.geolocation) {
      this.locationEnabled = true;
    } else {
      this.locationEnabled = false;
    }

    if(window.innerWidth < 768) {
      this.isMobile = true;
    }
    console.log(this.isMobile +":"+this.locationEnabled);
  }

  toggleUserBlock(event) {
    event.preventDefault();
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

  onResize(event) {
    if(window.innerWidth < 768) {
      this.isMobile = true;
    } else {
      this.isMobile = false;
    }
  }  
}
