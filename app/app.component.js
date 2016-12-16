System.register(['@angular/core', './core/settings/settings.service'], function(exports_1, context_1) {
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
    var core_1, settings_service_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent(settings) {
                    this.settings = settings;
                }
                Object.defineProperty(AppComponent.prototype, "isFixed", {
                    get: function () {
                        return this.settings.layout.isFixed;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "isCollapsed", {
                    get: function () {
                        return this.settings.layout.isCollapsed;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "isBoxed", {
                    get: function () {
                        return this.settings.layout.isBoxed;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "useFullLayout", {
                    get: function () {
                        return this.settings.layout.useFullLayout;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "hiddenFooter", {
                    get: function () {
                        return this.settings.layout.hiddenFooter;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "horizontal", {
                    get: function () {
                        return this.settings.layout.horizontal;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "isFloat", {
                    get: function () {
                        return this.settings.layout.isFloat;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "offsidebarOpen", {
                    get: function () {
                        return this.settings.layout.offsidebarOpen;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "asideToggled", {
                    get: function () {
                        return this.settings.layout.asideToggled;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                Object.defineProperty(AppComponent.prototype, "isCollapsedText", {
                    get: function () {
                        return this.settings.layout.isCollapsedText;
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                AppComponent.prototype.ngOnInit = function () {
                    $(document).on('click', '[href="#"]', function (e) { return e.preventDefault(); });
                };
                __decorate([
                    core_1.HostBinding('class.layout-fixed'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "isFixed", null);
                __decorate([
                    core_1.HostBinding('class.aside-collapsed'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "isCollapsed", null);
                __decorate([
                    core_1.HostBinding('class.layout-boxed'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "isBoxed", null);
                __decorate([
                    core_1.HostBinding('class.layout-fs'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "useFullLayout", null);
                __decorate([
                    core_1.HostBinding('class.hidden-footer'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "hiddenFooter", null);
                __decorate([
                    core_1.HostBinding('class.layout-h'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "horizontal", null);
                __decorate([
                    core_1.HostBinding('class.aside-float'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "isFloat", null);
                __decorate([
                    core_1.HostBinding('class.offsidebar-open'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "offsidebarOpen", null);
                __decorate([
                    core_1.HostBinding('class.aside-toggled'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "asideToggled", null);
                __decorate([
                    core_1.HostBinding('class.aside-collapsed-text'), 
                    __metadata('design:type', Object)
                ], AppComponent.prototype, "isCollapsedText", null);
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'app-root',
                        template: '<router-outlet></router-outlet>',
                        encapsulation: core_1.ViewEncapsulation.None
                    }), 
                    __metadata('design:paramtypes', [settings_service_1.SettingsService])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
