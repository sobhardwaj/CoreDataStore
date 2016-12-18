System.register(['@angular/core', './settings/settings.service', './themes/themes.service', './menu/menu.service', './module-import-guard'], function(exports_1, context_1) {
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
    var __param = (this && this.__param) || function (paramIndex, decorator) {
        return function (target, key) { decorator(target, key, paramIndex); }
    };
    var core_1, settings_service_1, themes_service_1, menu_service_1, module_import_guard_1;
    var CoreModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            },
            function (themes_service_1_1) {
                themes_service_1 = themes_service_1_1;
            },
            function (menu_service_1_1) {
                menu_service_1 = menu_service_1_1;
            },
            function (module_import_guard_1_1) {
                module_import_guard_1 = module_import_guard_1_1;
            }],
        execute: function() {
            CoreModule = (function () {
                function CoreModule(parentModule) {
                    module_import_guard_1.throwIfAlreadyLoaded(parentModule, 'CoreModule');
                }
                CoreModule = __decorate([
                    core_1.NgModule({
                        imports: [],
                        providers: [
                            settings_service_1.SettingsService,
                            themes_service_1.ThemesService,
                            menu_service_1.MenuService
                        ],
                        declarations: [],
                        exports: []
                    }),
                    __param(0, core_1.Optional()),
                    __param(0, core_1.SkipSelf()), 
                    __metadata('design:paramtypes', [CoreModule])
                ], CoreModule);
                return CoreModule;
            }());
            exports_1("CoreModule", CoreModule);
        }
    }
});
