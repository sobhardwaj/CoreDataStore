System.register(['@angular/core', '@angular/common', '@angular/forms', '@angular/router', '@angular/http', 'ng2-bootstrap/ng2-bootstrap', 'ng2-select/ng2-select', 'angular2-toaster/angular2-toaster', './colors/colors.service', './services/session', './directives/checkall', './directives/now', './directives/scrollable', './pipes/capitalize', './pipes/trim'], function(exports_1, context_1) {
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
    var core_1, common_1, forms_1, router_1, http_1, ng2_bootstrap_1, ng2_select_1, angular2_toaster_1, colors_service_1, session_1, checkall_1, now_1, scrollable_1, capitalize_1, trim_1;
    var SharedModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (common_1_1) {
                common_1 = common_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (ng2_bootstrap_1_1) {
                ng2_bootstrap_1 = ng2_bootstrap_1_1;
            },
            function (ng2_select_1_1) {
                ng2_select_1 = ng2_select_1_1;
            },
            function (angular2_toaster_1_1) {
                angular2_toaster_1 = angular2_toaster_1_1;
            },
            function (colors_service_1_1) {
                colors_service_1 = colors_service_1_1;
            },
            function (session_1_1) {
                session_1 = session_1_1;
            },
            function (checkall_1_1) {
                checkall_1 = checkall_1_1;
            },
            function (now_1_1) {
                now_1 = now_1_1;
            },
            function (scrollable_1_1) {
                scrollable_1 = scrollable_1_1;
            },
            function (capitalize_1_1) {
                capitalize_1 = capitalize_1_1;
            },
            function (trim_1_1) {
                trim_1 = trim_1_1;
            }],
        execute: function() {
            // https://angular.io/styleguide#!#04-10
            SharedModule = (function () {
                function SharedModule() {
                }
                SharedModule = __decorate([
                    core_1.NgModule({
                        imports: [
                            common_1.CommonModule,
                            forms_1.FormsModule,
                            forms_1.ReactiveFormsModule,
                            ng2_bootstrap_1.Ng2BootstrapModule,
                            ng2_select_1.SelectModule,
                            angular2_toaster_1.ToasterModule
                        ],
                        providers: [
                            colors_service_1.ColorsService,
                            session_1.SessionService
                        ],
                        declarations: [
                            trim_1.TrimPipe,
                            capitalize_1.CapitalizePipe,
                            checkall_1.CheckallDirective,
                            now_1.NowDirective,
                            scrollable_1.ScrollableDirective
                        ],
                        exports: [
                            common_1.CommonModule,
                            forms_1.FormsModule,
                            forms_1.ReactiveFormsModule,
                            http_1.HttpModule,
                            router_1.RouterModule,
                            ng2_bootstrap_1.Ng2BootstrapModule,
                            angular2_toaster_1.ToasterModule,
                            trim_1.TrimPipe,
                            capitalize_1.CapitalizePipe,
                            checkall_1.CheckallDirective,
                            now_1.NowDirective,
                            scrollable_1.ScrollableDirective
                        ]
                    }), 
                    __metadata('design:paramtypes', [])
                ], SharedModule);
                return SharedModule;
            }());
            exports_1("SharedModule", SharedModule);
        }
    }
});
