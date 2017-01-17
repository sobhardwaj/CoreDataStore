System.register(['@angular/core', './layout.component', './sidebar/sidebar.component', './header/header.component', './header/navsearch/navsearch.component', './footer/footer.component', '../shared/shared.module'], function(exports_1, context_1) {
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
    var core_1, layout_component_1, sidebar_component_1, header_component_1, navsearch_component_1, footer_component_1, shared_module_1;
    var LayoutModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (layout_component_1_1) {
                layout_component_1 = layout_component_1_1;
            },
            function (sidebar_component_1_1) {
                sidebar_component_1 = sidebar_component_1_1;
            },
            function (header_component_1_1) {
                header_component_1 = header_component_1_1;
            },
            function (navsearch_component_1_1) {
                navsearch_component_1 = navsearch_component_1_1;
            },
            function (footer_component_1_1) {
                footer_component_1 = footer_component_1_1;
            },
            function (shared_module_1_1) {
                shared_module_1 = shared_module_1_1;
            }],
        execute: function() {
            LayoutModule = (function () {
                function LayoutModule() {
                }
                LayoutModule = __decorate([
                    core_1.NgModule({
                        imports: [
                            shared_module_1.SharedModule
                        ],
                        providers: [],
                        declarations: [
                            layout_component_1.LayoutComponent,
                            sidebar_component_1.SidebarComponent,
                            header_component_1.HeaderComponent,
                            navsearch_component_1.NavsearchComponent,
                            footer_component_1.FooterComponent
                        ],
                        exports: [
                            layout_component_1.LayoutComponent,
                            sidebar_component_1.SidebarComponent,
                            header_component_1.HeaderComponent,
                            navsearch_component_1.NavsearchComponent,
                            footer_component_1.FooterComponent
                        ]
                    }), 
                    __metadata('design:paramtypes', [])
                ], LayoutModule);
                return LayoutModule;
            }());
            exports_1("LayoutModule", LayoutModule);
        }
    }
});
