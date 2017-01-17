System.register(['@angular/core'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1;
    var ThemesService;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            // const themeA = require('../../shared/styles/themes/theme-a.scss');
            // const themeB = require('../../shared/styles/themes/theme-b.scss');
            // const themeC = require('../../shared/styles/themes/theme-c.scss');
            // const themeD = require('../../shared/styles/themes/theme-d.scss');
            // const themeE = require('../../shared/styles/themes/theme-e.scss');
            // const themeF = require('../../shared/styles/themes/theme-f.scss');
            // const themeG = require('../../shared/styles/themes/theme-g.scss');
            // const themeH = require('../../shared/styles/themes/theme-h.scss');
            ThemesService = (function () {
                function ThemesService() {
                    this.defaultTheme = 'A';
                    this.createStyle();
                    this.setTheme(this.defaultTheme);
                }
                ThemesService.prototype.createStyle = function () {
                    var head = document.head || document.getElementsByTagName('head')[0];
                    this.styleTag = document.createElement('style');
                    this.styleTag.type = 'text/css';
                    this.styleTag.id = 'appthemes';
                    head.appendChild(this.styleTag);
                };
                ThemesService.prototype.setTheme = function (name) {
                    return;
                    // switch (name) {
                    //   case 'A':
                    //     this.injectStylesheet(themeA);
                    //     break;
                    //   case 'B':
                    //     this.injectStylesheet(themeB);
                    //     break;
                    //   case 'C':
                    //     this.injectStylesheet(themeC);
                    //     break;
                    //   case 'D':
                    //     this.injectStylesheet(themeD);
                    //     break;
                    //   case 'E':
                    //     this.injectStylesheet(themeE);
                    //     break;
                    //   case 'F':
                    //     this.injectStylesheet(themeF);
                    //     break;
                    //   case 'G':
                    //     this.injectStylesheet(themeG);
                    //     break;
                    //   case 'H':
                    //     this.injectStylesheet(themeH);
                    //     break;
                    // }
                };
                ThemesService.prototype.injectStylesheet = function (css) {
                    this.styleTag.innerHTML = css;
                };
                ThemesService.prototype.getDefaultTheme = function () {
                    return this.defaultTheme;
                };
                ThemesService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [])
                ], ThemesService);
                return ThemesService;
            }());
            exports_1("ThemesService", ThemesService);
        }
    }
});
